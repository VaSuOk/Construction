using System;
using System.Collections.Generic;
using System.Text;

namespace Construction.Auxiliary_classes
{
    class WorkStatus
    {
        public List<string> status { get; set; }
        public WorkStatus()
        {
            SetWorkStatus();
        }
        public void SetWorkStatus()
        {
            status = new List<string>()
            {
                "Очікування",
                "Активність"
            };
        }
        public static bool GetBoolStatus(string status)
        {
            if (status == "Активність")
                return true;
            else //умова
                return false;
        }
    }
}
