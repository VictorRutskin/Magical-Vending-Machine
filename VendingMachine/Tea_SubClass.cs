using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public  class Tea_SubClass : Beverage_Class //tea must contain grass, if we set the first ingridient as something other than grass, it will be change to grass.
    {

        Ingridients_Class Grass = new Ingridients_Class(1, "Grass");
        public Tea_SubClass(int imageNum, string Name = "", params Ingridients_Class[] LocalIngridients) : base(Name, imageNum, LocalIngridients)
        {
            LocalIngridients[0] = Grass;

        }


        public override string Prepare_Beverage() //Tea is adding Sugar
        {
            return $"Adding {Ingridients[0].Name}  Adding {Ingridients[1].Name}  Adding {Ingridients[2].Name}  Adding A Sliced Lemon  Adding Sugar";
        }
    }

  
}
