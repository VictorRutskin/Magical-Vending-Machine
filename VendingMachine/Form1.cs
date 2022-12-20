using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Form1 : Form
    {

        VendingMachine_Class vendingMachine_Class = new VendingMachine_Class(); // to use the vending machine methods
        Ingridients_Class ingridients_Class = new Ingridients_Class(); // to use ingridients class
        Button[] Buttons = new Button[10];
        public Form1()
        {
            InitializeComponent();
            //this.TransparencyKey = Color.White;
            //this.BackColor = Color.White;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            Buttons[0] = button1;
            Buttons[1] = button2;
            Buttons[2] = button3;
            Buttons[3] = button4;
            Buttons[4] = button5;
            Buttons[5] = button6;
            Buttons[6] = button7;
            Buttons[7] = button8;
            Buttons[8] = button9;
            Buttons[9] = button10;

            vendingMachine_Class.NormalMachineMessage(textBox1, "This Vending Machine Consumes Coins From Your Soul @_@ What Would You Like?");

            textBox2.Text = ("Cup Counter:" + 5);


            vendingMachine_Class.AddBeverage("Soft Drink", "Apple Juice", 0, ingridients_Class.ReturnIgridients(2, 3, 9));
            vendingMachine_Class.AddBeverage("Soft Drink", "Regular Lemonade", 1, ingridients_Class.ReturnIgridients(1, 1, 1));
            vendingMachine_Class.AddBeverage("Soft Drink", "Void Soft Drink", 2, ingridients_Class.ReturnIgridients(3, 8, 8));

            vendingMachine_Class.AddBeverage("Tea", "Dragon's Breath Tea", 3, ingridients_Class.ReturnIgridients(1, 4, 5)); // first ingridiesnt isnt grass, but still will be.
            vendingMachine_Class.AddBeverage("Tea", "Sad Day Tea", 4, ingridients_Class.ReturnIgridients(2, 3, 6));
            vendingMachine_Class.AddBeverage("Tea", "Poor Man's Tea", 5, ingridients_Class.ReturnIgridients(2, 2, 2));

            vendingMachine_Class.AddBeverage("Coffee", "Commoner's Coffee", 6, ingridients_Class.ReturnIgridients(7, 6, 2));
            vendingMachine_Class.AddBeverage("Coffee", "Enigmatic Awakening Coffee", 7, ingridients_Class.ReturnIgridients(4, 8, 10)); //first ingridiesnt isnt coffee, but still will be.
            vendingMachine_Class.AddBeverage("Coffee", "Last Day Alive Coffee", 8, ingridients_Class.ReturnIgridients(7, 1, 9));


            vendingMachine_Class.AddBeverage("Soft Drink", "Borgar Drink", 1, ingridients_Class.ReturnIgridients(0, 5, 10)); //random image recycled new drink
            vendingMachine_Class.AddBeverage("Coffee", "Hmmmmm", 2, ingridients_Class.ReturnIgridients(1, 4, 9)); //random image recycled new drink

            vendingMachine_Class.AddBeverage("Tea", "Fella That Wont Work", 3, ingridients_Class.ReturnIgridients(1, 1, 1)); //wont work in purpose to show filtering
            vendingMachine_Class.AddBeverage("Tea", "Fella That Wont Work too", 4, ingridients_Class.ReturnIgridients(2, 4, 5));  //wont work in purpose to show filtering

            vendingMachine_Class.RemoveBeverage("Regular Lemonade");


            setButtonNames();
            CheckIfValid();

           

        }
        public Font CheckingStringLength(string str)
        {
            if (str.Length <= 10)
            {
                Font BigFont = new Font("Arial", 20);

                return BigFont;
            }

            else if (str.Length > 10 && str.Length <= 20)
            {
                Font MediumFont = new Font("Arial", 15);

                return MediumFont;
            }

            else if (str.Length > 20 && str.Length <= 30)
            {
                Font SmallFont = new Font("Arial", 10);

                return SmallFont;
            }

            else if (str.Length > 30)
            {
                Font VerySmallFont = new Font("Arial", 5);

                return VerySmallFont;
            }
            return null;

        }
        public void setButtonNames()
        {

            button1.Text = vendingMachine_Class.ReturnBevName(0);
            button2.Text = vendingMachine_Class.ReturnBevName(1);
            button3.Text = vendingMachine_Class.ReturnBevName(2);
            button4.Text = vendingMachine_Class.ReturnBevName(3);
            button5.Text = vendingMachine_Class.ReturnBevName(4);
            button6.Text = vendingMachine_Class.ReturnBevName(5);
            button7.Text = vendingMachine_Class.ReturnBevName(6);
            button8.Text = vendingMachine_Class.ReturnBevName(7);
            button9.Text = vendingMachine_Class.ReturnBevName(8);
            button10.Text = vendingMachine_Class.ReturnBevName(9);

            button1.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(0));
            button2.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(1));
            button3.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(2));
            button4.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(3));
            button5.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(4));
            button6.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(5));
            button7.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(6));
            button8.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(7));
            button9.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(8));
            button10.Font = CheckingStringLength(vendingMachine_Class.ReturnBevName(9));

        }

        public void CheckIfValid() //checks if has name, if not = unfunctional
        {
            for(int i = 0; i < 10; i++)
            {
                if (Buttons[i].Text == "")
                {
                    Buttons[i].Enabled = false;
                }
            }

        }

        //public async void ButtonsVisbleWhenNeeded()
        //{
        //    int i = 1;
        //    while(i == 1)
        //    {
        //        if(textBox1.Text == "Enjoy Your Beverage!  Click on it to take it!")
        //        {
        //            functionAllButtons("True");
        //            await Task.Delay(1000);
        //        }

        //    }
        //}

        public PictureBox[] ReturnPicture(Ingridients_Class[] ingridients)
        {

            if(ingridients.Length>3)
            {
                throw new InvalidOperationException("amount of ingridients cant be more than 3");
            }

            PictureBox[] AllPictures = new PictureBox[12]; //can fit max of 12 ingridients in vending machine

            PictureBox[] SelectedPictures = new PictureBox[3];

            for (int i = 0; i < ingridients.Length; i++)
            {
                if (ingridients[i].Name == "Magical Mushrooms")
                {
                    SelectedPictures[i] = Ingridient_Magic_Mushrooms_Picture;
                }
                else if (ingridients[i].Name == "Golden Frog's Poison")
                {
                    SelectedPictures[i] = Ingridient_Golden_Frogs_Poison_Picture;
                }
                else if (ingridients[i].Name == "Grass")
                {
                    SelectedPictures[i] = Ingridient_Grass_Picture;
                }
                else if (ingridients[i].Name == "Gnome Tears")
                {
                    SelectedPictures[i] = Ingridient_Gnome_Tears_Picture;
                }
                else if (ingridients[i].Name == "Dragon's Scale")
                {
                    SelectedPictures[i] = Ingridient_Dragons_Scale_Picture;
                }
                else if (ingridients[i].Name == "Pheonix Egg")
                {
                    SelectedPictures[i] = Ingridient_Pheonix_Egg_Picture;
                }
                else if (ingridients[i].Name == "Farmer's blood")
                {
                    SelectedPictures[i] = Ingridient_Farmers_Blood_Picture;
                }
                else if (ingridients[i].Name == "Cursed Coffee Beans")
                {
                    SelectedPictures[i] = Ingridient_Cursed_CoffeeBeans_Picture;
                }
                else if (ingridients[i].Name == "Black Liquid")
                {
                    SelectedPictures[i] = Ingridient_Black_Liquid_Picture;
                }
                else if (ingridients[i].Name == "Witch Nails")
                {
                    SelectedPictures[i] = Ingridient_Witch_Nails_Picture;
                }

            }

            return SelectedPictures;
        }

      
        public void functionAllButtons(string Flag)
        {
            if(Flag != "True" && Flag != "False")
            {
                throw new InvalidOperationException("String in functionAllButtons can be only True/False");
            }

            if (Flag == "True")
            {
                for (int i = 0; i < Buttons.Length; i++)
                {
                    Buttons[i].Enabled = true;
                }
            }
            else if (Flag == "False")
            {
                for (int i = 0; i < Buttons.Length; i++)
                {
                    Buttons[i].Enabled = false;
                }
            }          

        }

        public async void GlobalClickEffect(int number)
        {
            functionAllButtons("False");

            try
            {
                vendingMachine_Class.ShowStringInMachine(textBox1, number, ReturnPicture(vendingMachine_Class.GetDrinkIngridients(number)), pictureBox1, pictureBox2, textBox2);
                await Task.Delay(17000); //17 sec
            }

            catch (Exception Error)
            {
                textBox1.Text = "The Machine Cannot Work Because: " + Error.Message;
            }

            functionAllButtons("True");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private  void button1_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(1);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(2);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(3);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(4);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(5);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(6);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(7);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(8);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            GlobalClickEffect(9);
        }

        private void Ingridient_Grass_Picture_Click(object sender, EventArgs e)
        {

        }

        private void Ingridient_Magic_Mushrooms_Picture_Click(object sender, EventArgs e)
        {

        }

        private void Ingridient_Golden_Frogs_Poison_Picture_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
