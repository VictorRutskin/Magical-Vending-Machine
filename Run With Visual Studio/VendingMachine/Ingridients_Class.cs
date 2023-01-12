using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Ingridients_Class
    {
        private int _Ingridient_Price { get; set; }
        private string _Ingridient_Name { get; set; }



        public Ingridients_Class(int ingridient_Price = 0, string ingridient_Name = "")
        {
            _Ingridient_Price = ingridient_Price;
            _Ingridient_Name = ingridient_Name;

        }

        public string Name
        {
            get { return _Ingridient_Name; }
            set { _Ingridient_Name = value; }
        }

        public int price
        {
            get { return _Ingridient_Price; }
            set { _Ingridient_Price = value; }
        }

        public Ingridients_Class[] ReturnIgridients(int igridient1, int igridient2, int igridient3)
        {
            Ingridients_Class Magical_Mushrooms = new Ingridients_Class(10, "Magical Mushrooms");
            Ingridients_Class Golden_Frogs_Poison = new Ingridients_Class(20, "Golden Frog's Poison");
            Ingridients_Class Grass = new Ingridients_Class(1, "Grass");
            Ingridients_Class Gnome_Tears = new Ingridients_Class(8, "Gnome Tears");
            Ingridients_Class Dragons_Scale = new Ingridients_Class(35, "Dragon's Scale");
            Ingridients_Class Pheonix_Egg = new Ingridients_Class(60, "Pheonix Egg");
            Ingridients_Class Farmers_Blood = new Ingridients_Class(5, "Farmer's blood");
            Ingridients_Class Cursed_Coffee_Beans = new Ingridients_Class(12, "Cursed Coffee Beans");
            Ingridients_Class Black_Liquid = new Ingridients_Class(2, "Black Liquid");
            Ingridients_Class Witch_Nails = new Ingridients_Class(16, "Witch Nails");

            Ingridients_Class[] AllIngridients = new Ingridients_Class[12];
            AllIngridients[0] = Magical_Mushrooms;
            AllIngridients[1] = Golden_Frogs_Poison;
            AllIngridients[2] = Grass;
            AllIngridients[3] = Gnome_Tears;
            AllIngridients[4] = Dragons_Scale;
            AllIngridients[5] = Pheonix_Egg;
            AllIngridients[6] = Farmers_Blood;
            AllIngridients[7] = Cursed_Coffee_Beans;
            AllIngridients[8] = Black_Liquid;
            AllIngridients[9] = Magical_Mushrooms;
            AllIngridients[10] = Witch_Nails;

            Ingridients_Class[] localIngridients = new Ingridients_Class[3];
            localIngridients[0] = AllIngridients[igridient1];
            localIngridients[1] = AllIngridients[igridient2];
            localIngridients[2] = AllIngridients[igridient3];

            return localIngridients;
        }

       

    }
}
