using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_run
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OnStart();
        }

        Rectangle Car;


        SolidBrush greenBrush = new SolidBrush(Color.Green);

        // side to side speed
        bool arrowleft = false;
        bool arrowright = false;

        // up down speed
        bool arrowup = false;
        bool arrowdown = false;

        int updownSpeed = 5;
        int sideSpeed = 5;

        int carAngle = 0;

        int carsSpeed = 5;

        int widthCar = 15;
        int heightCar = 30;
        int carSpeed = 10;



        //int angle;

        public void OnStart()
        {
            // staring value for 
            int carsSpeed = 5;
            int carAngle = 0;
            int widthCar = 15;
            int heightCar = 30;
            int carSpeed = 10;

            int xCar = this.Width / 2 - widthCar / 2;
            int yCar = this.Height - 50;

            Car = new Rectangle(xCar, yCar, widthCar, heightCar);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    arrowup = true;
                    break;
                case Keys.Down:
                    arrowdown = true;
                    break;
                case Keys.Left:
                    arrowleft = true;
                    break;
                case Keys.Right:
                    arrowright = true;
                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    arrowup = false;
                    break;
                case Keys.Down:
                    arrowdown = false;
                    break;
                case Keys.Left:
                    arrowleft = false;
                    break;
                case Keys.Right:
                    arrowright = false;
                    break;

            }
        }

        private void testTimer_Tick(object sender, EventArgs e)
        {
            // move up and dwon 
            if (arrowup == true)
            {
               movecarBakcwards();
            }
            if (arrowdown == true)
            {
                movecarForwand();
            }


            //turn the car 
            if (arrowleft == true)
            {

                carAngle -= 8;
            }
            if (arrowright == true)
            {
              
                carAngle +=8;
            }


            //redraw the screen
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(widthCar / 2 + Car.X, widthCar / 2 + Car.Y);

            e.Graphics.RotateTransform(carAngle);

            e.Graphics.FillRectangle(greenBrush, 0 - widthCar / 2, 0 - widthCar / 2, widthCar, heightCar);

            e.Graphics.ResetTransform();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void movecarForwand()
        {
            double angleInRadian = Math.PI * carAngle / 180;
            int deltaY = (int)(carSpeed * Math.Cos(angleInRadian));
            int deltaX = (int)(carSpeed * Math.Sin(angleInRadian));



            Car.Y += deltaY;
            Car.X -= deltaX;

            this.Refresh();
        }

        public void movecarBakcwards()
        {
            double angleInRadian = Math.PI * carAngle / 180;
            int deltaY = (int)(carSpeed * Math.Cos(angleInRadian));
            int deltaX = (int)(carSpeed * Math.Sin(angleInRadian));

            Car.Y -= deltaY;
            Car.X += deltaX;
        }

    }
}



