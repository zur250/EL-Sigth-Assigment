using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EL_SigthClient.Model;

namespace EL_SigthClient.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        #region Commands

        private DelegateCommand m_StreamBtnCommand; // Command for start/stop streaming

        public DelegateCommand StreamBtnCommand
        {
            get { return m_StreamBtnCommand ?? (m_StreamBtnCommand = new DelegateCommand(StreamBtnClicked)); }
        }

        private void StreamBtnClicked()
        {
            if (m_IsStreaming)
            { // Stream is on -> need to stop streaming
                m_IsStreaming = false;
                StreamContent = Strings.s_StartStream;
                ClientModel.Instance.StopStream();
            }
            else
            {// Stream is off -> need to start streaming
                m_IsStreaming = true;
                StreamContent = Strings.s_StopStream;
                ClientModel.Instance.StartStream();
            }
        }
        #endregion

        #region Private Members

        private string m_StreamBtnContent;
        private bool m_IsStreaming;
        private ObservableCollection<RandomNumberData> m_RandomNumberLst;
        private ObservableCollection<string> m_RandomStreamLst;
        private StringBuilder m_Builder;
        #endregion

        #region Properties
        public StringBuilder Builder
        {
            get { return m_Builder; }
            set
            {
                m_Builder.Append(value).Append(",");
                OnPropertyChanged("Builder");
            }
        }

        public string HomeTitle
        {
            get { return Strings.s_HomeTitle; }
        }

        public string StreamTitle
        {
            get { return Strings.s_RandomStreamTitle; }
        }
        public string NumberTitle
        {
            get { return Strings.s_RandomNumberTitle; }
        }
        public string StreamContent
        {
            get { return m_StreamBtnContent; }
            set
            {
                m_StreamBtnContent = value;
                OnPropertyChanged("StreamContent");
            }
        }

        public ObservableCollection<RandomNumberData> RandomNumberLst
        {
            get { return m_RandomNumberLst; }
            set
            {
                m_RandomNumberLst = value;
                OnPropertyChanged("RandomNumberLst");
            }
        }

        public ObservableCollection<string> RandomStreamLst
        {
            get { return m_RandomStreamLst; }
            set
            {
                m_RandomStreamLst = value;
                OnPropertyChanged("RandomStreamLst");
            }
        }


        #endregion

        #region Constructor

        public HomeViewModel()
        {
            ClientModel.Instance.RandomNumberEvent += M_Client_RandomNumberEvent;
            ClientModel.Instance.RandomStreamEvent += M_Client_RandomStreamEvent;
            this.StreamContent = Strings.s_StartStream;
            m_IsStreaming = false;
            m_RandomNumberLst = new ObservableCollection<RandomNumberData>();
            m_RandomStreamLst = new ObservableCollection<string>();
            m_Builder = new StringBuilder();
        }
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion

        #region Events Methods
        private void M_Client_RandomStreamEvent(byte[] i_RandomData)
        {
            i_RandomData.ToList().ForEach(
                value => m_Builder.Append(value).Append(","));
            string UIData = m_Builder.ToString();
            UIData = UIData.Substring(0, UIData.Length - 1); // remove last ,
            RandomStreamLst.Add(UIData);
            m_Builder.Clear();
        }

        private void M_Client_RandomNumberEvent(int i_RandomNum)
        {
            RandomNumberData newIncomeNumber = new RandomNumberData(i_RandomNum.ToString(), DateTime.Now.ToString("HH:mm:ss tt"));
            Console.WriteLine(i_RandomNum.ToString() + " At : " + DateTime.Now.ToString("HH:mm:ss tt"));
            RandomNumberLst.Add(newIncomeNumber);
        }
        #endregion
    }
}
