using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_magical_factory_2._0
{
    public class MagicalFactory
    {
        private Fabric myFabric = new();
        private Storage myStorage = new();

        public MagicalFactory()
        {

        }
        public void Run()
        {
            Recepies.CreateRecepies();
            while(true)
            {
                Console.WriteLine("Welecome to the Magical Factory\n");
                myStorage.ShowLager();
                myFabric.MaterialFromUser(myStorage.MaterialsFromStorageToFactory());
            }
        }
    }
}
