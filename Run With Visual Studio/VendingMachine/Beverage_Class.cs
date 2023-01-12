using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Beverage_Class   // CLASS WILL NOT BE ABSTRACT SO I CAN EASLY USE THE RETURNIMAGE OUTSIDE THIS CLASS
    {
        public Ingridients_Class[] Ingridients = new Ingridients_Class[3];
        Image[] FinalBevsimages = new Image[100]; // i keep or delete?

        private string _Beverage_Name { get; set; }
        private int _Beverage_Price { get; set; }
        private Image _Beverage_Image { get; set; }
        public static int _BeverageCounter { get; set; }


        public Beverage_Class(string Name ="",int imageNum=0, params Ingridients_Class[] LocalIngridients )  //constructor, default price is 5 shmekels
        {
            _Beverage_Name = Name;
            Ingridients = LocalIngridients;

            int price = 0;
            for( int i = 0; i < LocalIngridients.Length; i++ )
            {
                price = price + LocalIngridients[i].price;
            }
            _Beverage_Price = price;

            if(Name != "")
            {
                _BeverageCounter++;
            }

            _Beverage_Image = ReturnImage(imageNum);
        }
        public string Name
        {
            get { return _Beverage_Name; }
            set { _Beverage_Name = value; }
        }

        public int Price
        {
            get { return _Beverage_Price; }
            set { _Beverage_Price = value; }
        }

        public Image picture
        {
            get { return _Beverage_Image; }
            set { _Beverage_Image = value; }
        }

        public virtual string Prepare_Beverage()
        {
            return _Beverage_Image.ToString();
        }//sub class must not change order of preperation, but might change ingridients and the value of the objectives

        public Image ReturnImage(int num)
        {
            FinalBevsimages[0] = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"VendingMachinePictures\Drinks\SoftDrink_AppleJuice.png");
            FinalBevsimages[1] = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"VendingMachinePictures\Drinks\SoftDrink_RegularLemonade.png");
            FinalBevsimages[2] = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"VendingMachinePictures\Drinks\SoftDrink_Void.png");
            FinalBevsimages[3] = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"VendingMachinePictures\Drinks\Tea_DragonsBreath.png");
            FinalBevsimages[4] = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"VendingMachinePictures\Drinks\Tea_SadDay.png");
            FinalBevsimages[5] = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"VendingMachinePictures\Drinks\Tea_PoorMans.png");
            FinalBevsimages[6] = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"VendingMachinePictures\Drinks\Coffee_Commoner.png");
            FinalBevsimages[7] = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"VendingMachinePictures\Drinks\Coffee_EnigmaticAwakening.png");
            FinalBevsimages[8] = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"VendingMachinePictures\Drinks\Coffee_LastDayAlive.png");

            return FinalBevsimages[num];
        }
    }
}