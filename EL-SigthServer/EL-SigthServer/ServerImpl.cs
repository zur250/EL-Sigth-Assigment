using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace EL_SigthServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServerImpl : IServer
    {
        #region Delegate And Events
        #endregion

        #region Private Members

        private bool m_IsConnected;
        private bool m_SendRandomNumber;
        private bool m_SendStream;
        private IPubSubContract ServiceCallback = null;
        private List<IPubSubContract> m_NumberSubscribers; // Random number subscribers
        private List<IPubSubContract> m_StreamSubscribers; // random stream subscribers
        private Thread RandomNumThread;
        private Thread RandomStreamThread;
        #endregion

        #region Constructor

        public ServerImpl()
        {
            m_IsConnected = false;
            m_SendRandomNumber = true;
            m_SendStream = true;
            m_NumberSubscribers = new List<IPubSubContract>();
            m_StreamSubscribers = new List<IPubSubContract>();

            RandomNumThread = new Thread(SendRandomNumber);
            RandomStreamThread = new Thread(SedRandomStream);
            RandomNumThread.Start();
            RandomStreamThread.Start();
        }
        #endregion

        #region Server Methods Implementation
        public bool Login(string i_UserName, string i_password)
        {
            m_IsConnected = i_UserName == GlobalDefines.UserName && i_password == GlobalDefines.Password;
            if (m_IsConnected) // if connected we will insert to our Random number publisher subscriber pattern
            {
                ServiceCallback = OperationContext.Current.GetCallbackChannel<IPubSubContract>();
                if(!m_NumberSubscribers.Contains(ServiceCallback))
                    m_NumberSubscribers.Add(ServiceCallback);
            }
            return m_IsConnected;
        }

        public void StartStream()
        {
            if (m_IsConnected)
            {
                ServiceCallback = OperationContext.Current.GetCallbackChannel<IPubSubContract>();
                if (!m_StreamSubscribers.Contains(ServiceCallback))
                    m_StreamSubscribers.Add(ServiceCallback);
            }
        }

        public void StopStream()
        {
            if (m_IsConnected)
            {
                ServiceCallback = OperationContext.Current.GetCallbackChannel<IPubSubContract>();
                lock (ServiceCallback)
                {
                    m_StreamSubscribers.Remove(ServiceCallback);
                }
            }
        }


        #endregion

        #region private methods

        private void SendRandomNumber()
        {
            Random rnd = new Random();
            while (m_SendRandomNumber)
            {
                int rndnumber = rnd.Next();
                PublishRandomNumber(rndnumber);
                Thread.Sleep(5000);
            }
        }

        private void SedRandomStream()
        {
            Random rnd = new Random();
            Byte[] arr = new Byte[15];
            while (m_SendStream)
            {
                rnd.NextBytes(arr);
                PublishRandomData(arr);
                Thread.Sleep(200);
            }
        }

        private void PublishRandomNumber(int num)
        {
            foreach (IPubSubContract IPSC in m_NumberSubscribers.ToList())
            {
                try
                {
                    if (((IChannel)IPSC).State == CommunicationState.Opened)
                    {
                        IPSC.GetRandomNumber(num);
                    }
                    else // for some reason client disconnected
                    {
                        m_NumberSubscribers.Remove(IPSC);
                        m_IsConnected = false;
                    }
                }
                catch (Exception e)
                {
                }
            }

        }

        private void PublishRandomData(byte[] Data)
        {
            foreach (IPubSubContract IPSC in m_StreamSubscribers.ToList())
            {
                try
                {
                    if (((IChannel)IPSC).State == CommunicationState.Opened)
                    {
                        IPSC.GetRandomStream(Data);
                    }
                    else // for some reason client disconnected
                    {
                        m_StreamSubscribers.Remove(IPSC);
                        m_IsConnected = false;
                    }
                }
                catch (Exception e)
                {
                }
            }

        }
        #endregion
    }
}