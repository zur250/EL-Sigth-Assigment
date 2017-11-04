using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using EL_SigthClient.Model;

namespace EL_SigthClient.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Commands 
        private DelegateCommand<object> m_ConnectCommand; // Command for login button


        public DelegateCommand<object> ConnectCommand
        {
            get { return m_ConnectCommand ?? (m_ConnectCommand = new DelegateCommand<object>(Connect)); }
        }

       

        private void Connect(object i_Password)
        {
            Password = ((PasswordBox)i_Password).Password;
            bool isConnected = ClientModel.Instance.Login(UserName, Password);
            if (isConnected)
            {
                OpenHomeWindow();
            }
            else
            {
                ErrorMessegeBox();
            }
        }
        #endregion

        #region Private Members

        private string m_UserName;
        private string m_Password;
        #endregion

        #region Properties

        public string UserName
        {
            get { return m_UserName; }
            set
            {
                m_UserName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return m_Password; }
            set
            {
                m_Password = value;
                OnPropertyChanged("Password");
            }
        }
        public string UserNameLBL
        {
            get { return Strings.s_UserNamelbl; }
        }

        public string PasswordLBL
        {
            get { return Strings.s_Passwordlbl; }
        }

        public string LoginTitle
        {
            get { return Strings.s_LoginTitle; }
        }

        public string ConnectBtnContent
        {
            get { return Strings.s_Connectbtn; }
        }

        #endregion

        #region Constructor

        public LoginViewModel()
        {
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion


    }
}
