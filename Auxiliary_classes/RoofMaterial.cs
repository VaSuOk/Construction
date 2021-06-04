using System;
using System.Collections.Generic;
using System.Text;

namespace Construction.Auxiliary_classes
{
    class RoofMaterial
    {
        public List<string> Material;
        public RoofMaterial()
        {
            Material = new List<string>()
            {
                "Не обрано",
                "Металочерепиця",
                "Профнастил",
                "Ондулін",
                "Шифер",
                "Фальц"
            };
        }
    }
}
