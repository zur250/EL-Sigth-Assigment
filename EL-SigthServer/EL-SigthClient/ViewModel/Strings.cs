using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_SigthClient.ViewModel
{
    public class Strings
    {
        public enum WindowType { Login,Home,LoginError}

        public static readonly string s_MainHeader = "EL-Sigth Client,Server Exercise";
        public static readonly string s_LoginTitle = "Connect Window";
        public static readonly string s_HomeTitle = "Home Window";
        public static readonly string s_UserNamelbl = "User Name";
        public static readonly string s_Passwordlbl = "Password";
        public static readonly string s_Connectbtn = "Connect";
        public static readonly string s_RandomNumberTitle = "Service Random Number Publish";
        public static readonly string s_RandomStreamTitle = "Service Random Stream Publish";
        public static readonly string s_StartStream = "Start Stream";
        public static readonly string s_StopStream = "Stop  Stream";
        public static readonly string s_StreamHeader = "Service Random Stream Publish";
        public static readonly string s_NumberHeader = "Service Random Number Publish";
        public static readonly string s_MainForegroundColor = "#FFDA7E0F";
        public static readonly string s_RandomNumberText = "Recieved Number   :   ";
        public static readonly string s_RandomNumberTime = "    At   :   ";
    }
}
