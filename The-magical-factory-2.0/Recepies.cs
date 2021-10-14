using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_magical_factory_2._0
{
    public class Recepies
    {
        public static List<Recepies> _listOfAllRecepies = new List<Recepies>();

            public string Name { get; }
        public int WoodNeeded { get; }
        public int SteelNeeded { get; }
        public int PlasticNeeded { get; }
        public int RedPaintNeeded { get; }
        public int ScrewNeeded { get; }
        public int SumAllMaterialNeeded { get; }

        public Recepies(string name, int wood, int iron, int rubber, int rPaint, int screws)
        {
            Name = name;
            WoodNeeded = wood;
            PlasticNeeded = rubber;
            RedPaintNeeded = rPaint;
            ScrewNeeded = screws;
            SumAllMaterialNeeded = WoodNeeded + SteelNeeded + PlasticNeeded + RedPaintNeeded + ScrewNeeded;
            _listOfAllRecepies.Add(this);
        }

        public static void CreateRecepies()
        {
            Recepies axe = new Recepies("axe", 2, 1, 0, 1, 0);
            Recepies plunger = new Recepies("plunger", 1, 0, 1, 1, 0);
            Recepies chopsticks = new Recepies("chopsticks", 2, 0, 0, 0, 0);
            Recepies bicycle = new Recepies("bicycle", 0, 3, 1, 1, 2);
        }
    }
}
