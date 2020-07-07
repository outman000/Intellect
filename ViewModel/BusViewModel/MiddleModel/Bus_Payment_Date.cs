using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class Bus_Payment_Date
    {
        /// <summary>
        /////工作时间上午06:00
        /// </summary>
        public string _staWorkingDayAM { get; set; }


        /// <summary>
        /// //工作时间下午09:00
        /// </summary>
        public string _endWorkingDayAM { get; set; }



        /// <summary>
        /////工作时间上午17:00
        /// </summary>
        public string _staWorkingDayPM { get; set; }



        /// <summary>
        /////工作时间下午19:00
        /// </summary>
        public string _endWorkingDayPM { get; set; }
    }
}
