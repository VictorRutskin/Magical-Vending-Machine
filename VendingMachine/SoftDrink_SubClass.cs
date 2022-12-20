using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class SoftDrink_SubClass : Beverage_Class
    {

        public SoftDrink_SubClass(int imageNum, string Name = "", params Ingridients_Class[] LocalIngridients) : base(Name, imageNum, LocalIngridients)
        {
        }


        public override string Prepare_Beverage() // soft drink puts ice in the drink
        {
            return $"Adding {Ingridients[0].Name}  Adding {Ingridients[1].Name}  Adding {Ingridients[2].Name}  Adding Ice  Adding Cool Umbrella Decoration";
        }
    }

}
