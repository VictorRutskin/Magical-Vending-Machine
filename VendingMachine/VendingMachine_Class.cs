using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VendingMachine
{
    public class VendingMachine_Class  //vending machine is machical, the ingridients last forever! but it only has 3 cups!
    {

        Beverage_Class[] BeveragesArray = new Beverage_Class[100]; //max beverages for this machine to handle = 100, can only show 10 at a time, but if we delete one of the 10 the other will show! so i will keep it this way.

        private static int BeverageCounter { get; set; }
        private static int _Cups_Counter { get; set; }


        public VendingMachine_Class()
        {
            _Cups_Counter = 5;
            Ingridients_Class ingridients_Class = new Ingridients_Class(); // to use the calulating          

        }

        public int cups
        {
            get { return _Cups_Counter; }
            set { _Cups_Counter = value; }
        }

        public int Beverageamount
        {
            get { return _Cups_Counter; }
            set { _Cups_Counter = value; }
        }

        public Ingridients_Class[] GetDrinkIngridients(int position)
        {
            if (position < 0 || position > 100)
            {
                throw new InvalidOperationException("position in GetDrinkIngridients function must be higher than 0 and smaller than 101");
            }

            return BeveragesArray[position].Ingridients;
        }


        public void AddBeverage(string type, string name, int picNum, params Ingridients_Class[] LocalIngridients)
        {

            if (name == "")
            {
                throw new InvalidOperationException("Beverage must have a name.");
            }

            if (type != "Soft Drink" && type != "Tea" && type != "Coffee")
            {
                throw new InvalidOperationException("Invalid type.");
            }
                Ingridients_Class[] LocalIngridientsDuplicate = LocalIngridients.ToArray();

                bool checker = true;

                for (int i = 0; i < SoftDrink_SubClass._BeverageCounter; i++)
                {
                    if (checker == true)
                    {
                        Ingridients_Class[] ThisBevChecking = LocalIngridientsDuplicate.ToArray();
                        if (BeveragesArray[i] != null)
                        {
                            for (int j = 0; j < BeveragesArray[i].Ingridients.Length; j++) // amount if ingridients
                            {
                                for (int z = 0; z < ThisBevChecking.Length; z++)
                                {
                                    if (ThisBevChecking[z] != null)
                                    {
                                        if (BeveragesArray[i].Ingridients[j].Name == ThisBevChecking[z].Name)
                                        {
                                            ThisBevChecking[z] = null;
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                        int counter = 0;
                        for (int j = 0; j < ThisBevChecking.Length; j++)
                        {
                            if (ThisBevChecking[j] == null)
                            {
                                counter++;
                            }
                        }
                        if (counter == 3)
                        {
                            checker = false;
                        }
                    }
                }



                if (checker == true)
                {
                    if (type == "Soft Drink")
                    {
                        SoftDrink_SubClass NewSoftDrink = new SoftDrink_SubClass(picNum, name, LocalIngridients);
                        BeveragesArray[SoftDrink_SubClass._BeverageCounter - 1] = NewSoftDrink;
                        BeverageCounter = BeverageCounter + 1;
                    }
                    else if (type == "Tea")
                    {
                        Tea_SubClass NewTea = new Tea_SubClass(picNum, name, LocalIngridients);
                        BeveragesArray[SoftDrink_SubClass._BeverageCounter - 1] = NewTea;
                        BeverageCounter = BeverageCounter + 1;
                    }
                    else if (type == "Coffee")
                    {
                        Coffee_SubClass NewCoffee = new Coffee_SubClass(picNum, name, LocalIngridients);
                        BeveragesArray[SoftDrink_SubClass._BeverageCounter - 1] = NewCoffee;
                        BeverageCounter = BeverageCounter + 1;
                    }
                }
            
       
        }

        public void RemoveBeverage(string name)
        {

            for (int i = 0; i < BeverageCounter; i++)
            {
                if (BeveragesArray[i] != null)
                {
                    if (BeveragesArray[i].Name == name)
                    {
                        BeveragesArray[i] = null;

                        for (int j = 1; j < BeverageCounter + i; j++)
                        {
                            BeveragesArray[i + j - 1] = BeveragesArray[i + j];
                        }
                        BeveragesArray[BeverageCounter + 1] = null;
                        BeverageCounter--;
                    }
                }

            }
        }

        public string PrintPreparing(int beverage)
        {
            if (beverage < 0 || beverage > 100)
            {
                throw new InvalidOperationException("beverage in PrintPreparing function must be higher than 0 and smaller than 101");
            }

            return BeveragesArray[beverage].Prepare_Beverage();
        }

        public void NormalMachineMessage(TextBox textBox, string text)
        {
            textBox.Text = text;
        }

        public async void ShowStringInMachine(TextBox textBox, int BevNum, PictureBox[] IngridientsPictures, PictureBox openingPicture, PictureBox FinalProduct, TextBox cupTextBox)
        {

            if (this.cups > 0)
            {
                this.cups = this.cups - 1;
                cupTextBox.Text = ("Cup Counter:" + this.cups);
                openingPicture.Height = openingPicture.Height = 109; //reseing the vendingmachine door
                FinalProduct.BackgroundImage = null;

                string FullString = PrintPreparing(BevNum);
                string[] PartialStrings = new string[5];
                PartialStrings = System.Text.RegularExpressions.Regex.Split(FullString, @"\s{2,}");

                for (int i = 0; i < PartialStrings.Length; i++)
                {
                    textBox.Text = PartialStrings[i];
                    if (i < 3)
                    {
                        for (int j = 0; j < IngridientsPictures.Length; j++)
                        {
                            PickingUpEffect(IngridientsPictures[i], "Put");
                        }
                    }
                    await Task.Delay(2000);
                    textBox.Text = "";
                    await Task.Delay(500);
                }
                FinalProductEffect(BevNum, openingPicture, FinalProduct, textBox);

                await Task.Delay(3000);

                for (int i = 0; i < 3; i++)
                {
                    PickingUpEffect(IngridientsPictures[i], "Restore");
                }
            }
            else
            {
                textBox.Text = "There Are No More Cups Left";

                await Task.Delay(2000);
                textBox.Text = "";
                await Task.Delay(500);

                textBox.Text = "Please call 052-69696969 & Invite The Technician";

                await Task.Delay(2000);
                textBox.Text = "";
                await Task.Delay(500);

                textBox.Text = "That Can Manually Install More Magical Cups";

                await Task.Delay(2000);
                textBox.Text = "";
                await Task.Delay(500);

                textBox.Text = "Thank You And Have A Good Day!";

                await Task.Delay(2000);
                textBox.Text = "";
                await Task.Delay(500);

                textBox.Text = ":)";

                await Task.Delay(2000);
                textBox.Text = "";
                await Task.Delay(500);
            }

        }


        public async void PickingUpEffect(PictureBox picture, string putOrRestore)
        {

            if (putOrRestore != "Put" && putOrRestore != "Restore")
            {
                throw new InvalidOperationException("String in PickingUpEffect function can only be Put/Restore");
            }

            if (putOrRestore == "Put")
            {
                for (int j = 0; j < 10; j++)
                {
                    picture.Top += 30;
                    await Task.Delay(1);
                }
            }
            else if (putOrRestore == "Restore")
            {
                for (int j = 0; j < 10; j++)
                {
                    picture.Top -= 90;
                    await Task.Delay(1);
                }
            }
        }

        public async void FinalProductEffect(int BevNum, PictureBox openingPicture, PictureBox FinalProduct, TextBox textBox)
        {
            Beverage_Class beverage_Class = new Beverage_Class();
            //  Form1 form1 = new Form1();
            for (int j = 0; j < 100; j++)
            {
                openingPicture.Height -= openingPicture.Height / 10;
                await Task.Delay(1);
            }
            // FinalProduct.BackgroundImage = beverage_Class.ReturnImage(BevNum);
            FinalProduct.BackgroundImage = BeveragesArray[BevNum].picture;

            NormalMachineMessage(textBox, BeveragesArray[BevNum].Price+" Coins have been taken from your soul, Enjoy Your Beverage!  Click on it to take it!");
            //  form1.functionAllButtons("True");

        }

        public string ReturnBevName(int num)
        {
            if (num < 0 || num > 100)
            {
                throw new InvalidOperationException("Num in ReturnBevName function must be higher than 0 and smaller than 101");
            }
            if (BeveragesArray[num] != null)
            {
                return BeveragesArray[num].Name;
            }
            return "";
        }

    }
}
