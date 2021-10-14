using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_magical_factory_2._0
{
   public class Storage
    {
        public List<Material> listOfMaterials = new List<Material>();
        public static List<int> _listOfMaterialsAmount = new List<int>();
        public List<int> _materialstoSendNumbers = new List<int>();
        public static List<Recepies> _playerItems = new();

        public Storage()
        {
            listOfMaterials = new List<Material>();
            _listOfMaterialsAmount = new List<int>();
            _materialstoSendNumbers = new List<int>();
            AddList();
        }

        public void AddList()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Material)).Length; i++)
            {
                int randomNumber = new Random().Next(2, 10);
                _listOfMaterialsAmount.Add(randomNumber);
                listOfMaterials.Add((Material)i);
                _materialstoSendNumbers.Add(0);
            }
        }

        public void ShowLager()
        {
            Console.Clear();
            Console.WriteLine("The storage containt the following materials:  ");
            for (int i = 0; i < listOfMaterials.Count; i++)
            {
                Console.WriteLine($"{i + 1} . {listOfMaterials[i],10} - Amount: {_listOfMaterialsAmount[i]}");
            }

            if (_playerItems.Count > 0)
            {
                Console.WriteLine("You own the following products:   ");
                for (int i = 0; i < _playerItems.Count; i++)
                {
                    Console.WriteLine($" - {_playerItems[i].Name}");
                }
            }
            Console.WriteLine("");
        }
        public List<int> MaterialsFromStorageToFactory()
        {
            Console.WriteLine("");
            bool isDone = false;
            string sentMaterialsText = "";
            while (isDone == false)
            {
                ShowLager();
                Console.WriteLine(sentMaterialsText);
                for (int i = 0; i < _materialstoSendNumbers.Count; i++)
                {
                    if (_materialstoSendNumbers[i] > 0)
                    {
                        Console.WriteLine($"   - {listOfMaterials[i],10} -Amount: {_materialstoSendNumbers[i]}");
                    }
                }

                Console.WriteLine("\n What material do you want to send in to the fabric? \n\n Use numbers to pick material\n\n Press any other key to sent the materials to the fabric");

                var Userinput = Console.ReadKey();
                if (char.IsDigit(Userinput.KeyChar))
                {
                    int inputKey = int.Parse(Userinput.KeyChar.ToString());
                    inputKey--;
                    if (inputKey < _listOfMaterialsAmount.Count)
                    {
                        if (listOfMaterials[inputKey] > 0)
                        {
                            _listOfMaterialsAmount[inputKey] = _listOfMaterialsAmount[inputKey] - 1;
                            _materialstoSendNumbers[inputKey]++;

                            sentMaterialsText = "\nMaterials you want to send in is: \n";
                        }

                        else
                        {
                            Console.WriteLine($"{(Material)inputKey} is out of stock. Press enter to continue.");
                            Console.ReadKey();
                        }

                    }
                }
                else
                {
                    Console.Clear();
                    isDone = true;

                }
            }
            List<int> list2 = new List<int>(_materialstoSendNumbers.Count); //change list2 to a better name
            foreach (int item in _materialstoSendNumbers)
                list2.Add(item);
            for (int i = 0; i < _materialstoSendNumbers.Count; i++)
            {
                _materialstoSendNumbers[i] = 0;
            }

            return list2;

        }
    }
}
