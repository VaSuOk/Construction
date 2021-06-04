using System;
using System.Collections.Generic;
using System.Text;

namespace Construction.Auxiliary_classes
{
    class WallMaterial
    {
        public List<string> Material;
        public WallMaterial()
        {
            Material = new List<string>()
            {
                "Не обрано",
                "Селікатна цегла",
                "Керамічна цегла",
                "Керамічний блок",
                "Газоблок",
                "Ракушняк",
                "Шлакоблок"
            };
        }
    }
}
