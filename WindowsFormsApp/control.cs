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
    public class control : PictureBox
    {

        private System.ComponentModel.IContainer components = null;

        public int car_type = 0;

        private List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>(new System.Drawing.Bitmap[]
        {
            global::WindowsFormsApp.Properties.Resources.sports_car,
            global::WindowsFormsApp.Properties.Resources.passenger_car,
            global::WindowsFormsApp.Properties.Resources.truck
        });

        public control()
        {
            InitializeComponent();
            Image = images[car_type];
        }

        private void InitializeComponent()
        { 
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // control
            // 
            this.Image = global::WindowsFormsApp.Properties.Resources.sports_car;
            this.InitialImage = global::WindowsFormsApp.Properties.Resources.sports_car;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Size = new System.Drawing.Size(100, 100);
            this.Click += new System.EventHandler(this.control_Click);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void control_Click(object sender, EventArgs e)
        {
            car_type += 1;
            car_type = car_type % 3;
            Image = images[car_type];
        }
    }
}
