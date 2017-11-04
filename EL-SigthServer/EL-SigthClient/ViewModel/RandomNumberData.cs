using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EL_SigthClient.ViewModel
{
    public class RandomNumberData
    {
        #region Private Members

        private string m_Number;
        private string m_TimeRecieved;

        #endregion

        #region Properties

        public string NumberText
        {
            get { return Strings.s_RandomNumberText; }
        }

        public string TimeText
        {
            get { return Strings.s_RandomNumberTime; }
        }
        public string Number
        {
            get { return m_Number; }
            set
            {
                m_Number = value;
            }
        }

        public string TimeRecieved
        {
            get { return m_TimeRecieved; }
            set
            {
                m_TimeRecieved = value;
            }
        }
        #endregion

        #region Constructor

        public RandomNumberData(string i_Number,string i_TimeRecieved)
        {
            this.Number = i_Number;
            this.TimeRecieved = i_TimeRecieved;
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion
    }
}
