using System;
using System.Collections.Generic;
using System.Text;

namespace Сonstruction.Auxiliary_classes
{
    class Regions
    {
        public List<string> regions;
        public Regions()
        {
            InitRegions();
        }
        private void InitRegions()
        {
            regions = new List<string>
            {
                "Ужгород","Львів","Луцьк","Тернопіль","Рівне","Івано-Франківськ","Хмельницький","Житомир","Чернівці",
                "Вінниця","Київ","Чернігів","Черкаси","Полтава", "Суми","Кіровоград","Миколаїв","Одеса","Херсон","Дніпропретровськ",
                "Запоріжжя","Харків", "Н-А. Луганськ","Н-А. Донецьк", "Н-А. Сімферополь"
            };
        }
        public void AddRegionTypeAll()
        {
            regions.Add("Всі регіони");
        }
    }
}
