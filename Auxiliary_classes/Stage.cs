using System;
using System.Collections.Generic;
using System.Text;

namespace Construction.Auxiliary_classes
{
    class Stage
    {
        public List<string> stage;
        public Stage()
        {
            stage = new List<string>
            {
                "Фундамент",
                "Будівництво",
                "Покрівля",
                "Обробка"
            };
        }
    }
}
