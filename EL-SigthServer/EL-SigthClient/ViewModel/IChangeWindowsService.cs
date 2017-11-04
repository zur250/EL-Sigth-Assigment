using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_SigthClient.ViewModel
{
    public interface IChangeWindowsService
    {
        void AssignWindow();
        void CloseWindow();
        void OpenWindow(Strings.WindowType i_Type);
    }
}
