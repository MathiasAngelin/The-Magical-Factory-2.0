using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace The_magical_factory_2._0
{
    public class Fabric
    {
        private int _woodInFactory;
        private int _ironInFactory;
        private int _rubberInFactory;
        private int _redPaintInFactory;
        private int _screwsInFactory;
        public List<Material> MaterialsToSendToFabric;

        public Fabric()
        {

        }

        public void MaterialFromUser(List<int> inputMaterials)
        {
            _woodInFactory = inputMaterials[0];
            _ironInFactory = inputMaterials[1];
            _rubberInFactory = inputMaterials[2];
            _redPaintInFactory = inputMaterials[3];
            _screwsInFactory = inputMaterials[4];
            CheckMaterialAgainstRecepies();
        }

        private void CheckMaterialAgainstRecepies()
        {
            int topTotalMaterial = 0;
            int indexOfTopRecipe = 0;
            foreach (var item in Recepies._listOfAllRecepies)
            {
                if (item.WoodNeeded <= _woodInFactory && item.SteelNeeded <= _ironInFactory && item.PlasticNeeded <= _rubberInFactory && item.RedPaintNeeded <= _redPaintInFactory && item.ScrewNeeded <= _screwsInFactory)
                {
                    if (item.SumAllMaterialNeeded > topTotalMaterial)
                    {
                        topTotalMaterial = item.SumAllMaterialNeeded;
                        indexOfTopRecipe = Recepies._listOfAllRecepies.IndexOf(item);
                    }
                }
            }

            if (Recepies._listOfAllRecepies[indexOfTopRecipe].WoodNeeded <= _woodInFactory &&
                Recepies._listOfAllRecepies[indexOfTopRecipe].SteelNeeded <= _ironInFactory &&
                Recepies._listOfAllRecepies[indexOfTopRecipe].PlasticNeeded <= _rubberInFactory &&
                Recepies._listOfAllRecepies[indexOfTopRecipe].RedPaintNeeded <= _redPaintInFactory &&
                Recepies._listOfAllRecepies[indexOfTopRecipe].ScrewNeeded <= _screwsInFactory)
            {
                Console.WriteLine("item to create: {0}", Recepies._listOfAllRecepies[indexOfTopRecipe].Name);
                CreateItemFromRecipe(Recepies._listOfAllRecepies[indexOfTopRecipe]);
            }
            else
            {
                Console.WriteLine("Found noting to create ");
            }
        }

        private void CreateItemFromRecipe(Recepies recipe)
        {
            Random timeRando = new();
            Console.Write("Gathering rescourses ");
            string dotdotdot = ".";
            for (int i = 0; i < 10; i++)
            {
                Console.Write(dotdotdot);
                if (i % 4 == 0) { Console.Write("\b\b\b   \b\b\b"); }  //Haralds awesome animation for when the items are crafted.
                Thread.Sleep(timeRando.Next(50, 400));
            }
            Console.WriteLine();

            Console.WriteLine("Construction of {0} is starting ...", recipe.Name);
            Thread.Sleep(timeRando.Next(50, 400));              //pauses the game for random time to simulate the items beeing crafted.
            Storage._playerItems.Add(recipe);                   //curently using a static property in storage so we can change it from here.,. will be changed so we can have many difrent players.
            Console.WriteLine("Success!");
            Console.WriteLine("The {0} was added to your inventory.", recipe.Name);
            Thread.Sleep(700);
            Console.WriteLine("Checking if there anything else to make ..");

            _woodInFactory -= recipe.WoodNeeded; // ta bort material från inv i fabrik
            _ironInFactory -= recipe.SteelNeeded;
            _rubberInFactory -= recipe.PlasticNeeded;
            _redPaintInFactory -= recipe.RedPaintNeeded;
            _screwsInFactory -= recipe.ScrewNeeded;
            CheckMaterialAgainstRecepies(); // kör 


            Console.WriteLine("Your remaining material has been returned.");
            Storage._listOfMaterialsAmount[0] += _woodInFactory;           // static property in storage , might look beter with an other way to change that list in storage.
            Storage._listOfMaterialsAmount[1] += _ironInFactory;
            Storage._listOfMaterialsAmount[2] += _rubberInFactory;
            Storage._listOfMaterialsAmount[3] += _screwsInFactory;
            Storage._listOfMaterialsAmount[4] += _redPaintInFactory;
            _woodInFactory = 0;
            _ironInFactory = 0;
            _rubberInFactory = 0;
            _screwsInFactory = 0;   // resets the item inside the fabric objekt
            _redPaintInFactory = 0;

        }
    } 
}
