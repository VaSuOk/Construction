using Construction.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Construction.Auxiliary_classes
{
    public class ViewBrigade
    {
        public Brigade brigade { get; set; }
        public string wStatus { get; set; }
        public Brush brush { get; set; }
        public ViewBrigade(Brigade brigade)
        {
            this.brigade = brigade;
            SetWorkStatus();
        }
        public void SetWorkStatus()
        {
            if(brigade.TaskID != 0)
            {
                wStatus = "Виконується";
                brush =  Brushes.Green;
            }
            else
            {
                wStatus = "В очікуванні";
                brush = Brushes.Red;
            }
        }
    }
}
