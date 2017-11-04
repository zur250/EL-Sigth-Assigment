using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EL_SigthClient.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Private Members


        #endregion

        #region Properties

        public IChangeWindowsService ChangeWindowService { get; set; } // used to notify view to change window or pop up error messege box
        public string MainForegroundColor
        {
            get { return Strings.s_MainForegroundColor; }
        }

        public string MainTitle
        {
            get { return Strings.s_MainHeader; }
        }

        #endregion

        #region Constructor

        public BaseViewModel()
        {
            
        }
        #endregion

        #region Private Members
        #endregion

        #region Public Methods
        #endregion

        #region Protected Methods 
        protected void OpenHomeWindow()
        {
            ChangeWindowService.OpenWindow(Strings.WindowType.Home);
        }

        protected void ErrorMessegeBox()
        {
            ChangeWindowService.OpenWindow(Strings.WindowType.LoginError);
        }
        #endregion

        #region Property Change Implemantion
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
