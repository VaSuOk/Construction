using System;
using System.Collections.Generic;
using System.Text;

namespace Construction.Auxiliary_classes
{
    class TypeRoof
    {
        public List<string> type;
        public TypeRoof()
        {
            type = new List<string>()
            {
                "Плаский",
                "Односкатний",
                "Шатровий",
                "Двоскатний",
                "Багатоскатний"
            };
        }
    }
}
