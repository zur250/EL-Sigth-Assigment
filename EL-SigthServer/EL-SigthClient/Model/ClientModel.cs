using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using EL_SigthClient.ServerService;
using EL_SigthServer;

namespace EL_SigthClient.Model
{
    public class ClientModel : IServerCallback
    {
        #region Delegate And Events

        public delegate void RandomNumberDelegate(int i_RandomNum);  // Used to let know viewmodel for recieving Random Number from the service
        public event RandomNumberDelegate RandomNumberEvent; // Used to let know viewmodel for recieving Random Number from the service

        public delegate void RandomStreamDelegate(byte[] i_RandomData);  // Used to let know viewmodel for recieving Random Stream from the service
        public event RandomStreamDelegate RandomStreamEvent; // Used to let know viewmodel for recieving Random Stream from the service
        #endregion

        #region Private Members

        private static ClientModel m_Instance;
        private ServerService.ServerClient proxy;
        private bool m_isLogged;

        #endregion

        #region Properties

        public static ClientModel Instance
        {
            get
            {
                // TODO add lock for thread safe
                if (m_Instance == null)
                {
                    m_Instance = new ClientModel();
                }
                return m_Instance;
            }
        }

        public bool IsConnected
        {
            get { return this.m_isLogged; }
        }

        #endregion

        #region Constructor

        private ClientModel()
        {
            m_isLogged = false;
            proxy = new ServerClient(new InstanceContext(this));
        }

        #endregion

        #region Public Methods

        public bool Login(string i_Username, string i_Password)
        {
            bool isLogged = proxy.Login(i_Username, i_Password);
            return isLogged;
        }

        public void StartStream()
        {
            proxy.StartStream();
        }

        public void StopStream()
        {
            proxy.StopStream();
        }

        #endregion

        #region Service Subscriber Methods Implementation
        public void GetRandomNumber(int i_Number)
        {
            RandomNumberEvent?.Invoke(i_Number);
        }

        public void GetRandomStream(byte[] i_RandomData)
        {
            RandomStreamEvent?.Invoke(i_RandomData);
        }

        #endregion
    }
}
