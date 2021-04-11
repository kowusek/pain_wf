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
	public partial class MDI : Form
	{
		car_list cars = new car_list();

		public MDI()
		{
			InitializeComponent();
			IsMdiContainer = true;
			car_list_gui cars_form = new car_list_gui(cars);
			cars_form.MdiParent = this;
			cars_form.Show();
		}

		private void add_click(object sender, EventArgs e)
		{
			car_list_gui cars_form = new car_list_gui(cars);
			cars_form.MdiParent = this;
			cars_form.Show();
		}

		private void close_click(object sender, EventArgs e)
		{
			this.ActiveMdiChild.Close();
		}
	}
}