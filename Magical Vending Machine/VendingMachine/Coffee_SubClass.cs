using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Coffee_SubClass : Beverage_Class //coffee must contain cursed coffee beans, if we set the first ingridient as something other than coffee, it will be change to coffee.
    {
        Ingridients_Class Cursed_Coffee_Beans = new Ingridients_Class(12, "Cursed Coffee Beans");
        public Coffee_SubClass(int imageNum,string Name="", params Ingridients_Class[] LocalIngridients) : base( Name, imageNum, LocalIngridients)
        {
            LocalIngridients[0] = Cursed_Coffee_Beans;
        }


        public override string Prepare_Beverage() //coffee is Adding caffeine addictioned people's tears
        {
            return $"Adding {Ingridients[0].Name}  Adding {Ingridients[1].Name}  Adding {Ingridients[2].Name}  Adding Hot Goblin Bath Water  Adding Caffeine Addicted People's Sweat";
        }
    }
}

