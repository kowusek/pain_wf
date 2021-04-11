using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp
{
    public partial class car_editor_gui : Form
    {
        private car car;
        private List<car> cars;

        public car_editor_gui(car car, List<car> cars)
        {
            InitializeComponent();
            this.car = car;
            this.cars = cars;
        }

        public string brand
        {
            get { return textBox1.Text; }
        }

        public int max_speed
        {
            get { return int.Parse(textBox2.Text); }
        }

        public DateTime date_of_production
        {
            get { return dateTimePicker1.Value; }
        }

        public string type
        {
            get { return textBox4.Text; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void car_editor_gui_Load(object sender, EventArgs e)
        {
            if (car != null)
            {
                textBox1.Text = car.brand;
                textBox2.Text = car.max_speed.ToString();
                dateTimePicker1.Value = car.date_of_producion;
                textBox4.Text = car.type.ToString();
            }
            else
            {
                textBox1.Text = "Ford";
                textBox2.Text = "200";
                dateTimePicker1.Value = new DateTime(1980, 1, 1);
                textBox4.Text = genreControl1.Genre.ToString();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            
            Regex r = new Regex("^[a-zA-Z]*$");
            if (!r.IsMatch(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Brand can only be alpha");
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int max_speed = int.Parse(textBox2.Text);
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, exception.Message);
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, "");
        }

        private void genreControl1_Click(object sender, EventArgs e)
        {
            string enum_number = genreControl1.Genre.ToString();
            textBox4.Text = enum_number;
        }
    }
}
