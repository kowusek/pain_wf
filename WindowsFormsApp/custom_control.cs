using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp
{
    public partial class custom_control : UserControl
    {
        public event EventHandler Clicked;

        public car_type Genre
        {
            get { return (car_type)type; }
            set { type = value; }
        }
        public enum car_type
        {
            sports_car,
            passenger_car,
            truck
        }

        private car_type type;
        private List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>(new System.Drawing.Bitmap[] 
        {
            global::WindowsFormsApp.Properties.Resources.sports_car,
            global::WindowsFormsApp.Properties.Resources.passenger_car,
            global::WindowsFormsApp.Properties.Resources.truck
        });

        public custom_control()
        {
            InitializeComponent();
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            int index = (int)type;
            if (index == Enum.GetNames(typeof(car_type)).Length - 1)
            {
                index = 0;
                type = (car_type)index;
            } else
            {
                index++;
                type = (car_type)index;
            }
            Image image = images[index];
            pictureBox1.Image = image;
            pictureBox1.Invalidate();
            Clicked(this, e);
        }

        private void GenreControl_Load(object sender, EventArgs e)
        {
            type = (car_type)0;
            Image image = images[0];
            pictureBox1.Image = image;           
        }
    }
}