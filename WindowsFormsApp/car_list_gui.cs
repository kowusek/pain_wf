using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class car_list_gui : Form
	{
		private car_list cars { get; set; }
		private int car_count = 0;

		public car_list_gui(car_list cars)
		{
			InitializeComponent();
			this.cars = cars;
			update_count();
			update_command_availablility();
		}

		private void car_list_activated(object sender, EventArgs e)
		{
			ToolStripManager.Merge(toolStrip1, ((MDI)MdiParent).toolStrip1);
			ToolStripManager.Merge(statusStrip1, ((MDI)MdiParent).statusStrip1);
			this.toolStrip1.Visible = false;
			this.menuStrip1.Visible = false;
			this.statusStrip1.Visible = false;
		}

		private void car_list_deactivated(object sender, EventArgs e)
		{
			ToolStripManager.RevertMerge(((MDI)MdiParent).toolStrip1, toolStrip1);
			ToolStripManager.RevertMerge(((MDI)MdiParent).statusStrip1, statusStrip1);
			this.toolStrip1.Visible = true;
			this.menuStrip1.Visible = true;
			this.statusStrip1.Visible = true;
		}

        private void car_list_FormClosing(object sender, FormClosingEventArgs e)
        {
			if(((MDI)MdiParent).MdiChildren.Length <= 1)
				if(e.CloseReason != CloseReason.MdiFormClosing)
					e.Cancel = true;
		}

		private void update_count()
        {
			toolStripStatusLabel1.Text = this.car_count.ToString();
        }

		private void update_item(ListViewItem item)
		{
			car new_car = (car)item.Tag;
			while (item.SubItems.Count < 4)
				item.SubItems.Add(new ListViewItem.ListViewSubItem());
			item.SubItems[0].Text = new_car.brand;
			item.SubItems[1].Text = new_car.max_speed.ToString();
			item.SubItems[2].Text = new_car.date_of_producion.ToShortDateString();
			item.SubItems[3].Text = new_car.type;
		}

		private void update_items()
		{
			listView1.Items.Clear();
			foreach (car new_car in cars.cars)
			{
				ListViewItem item = new ListViewItem();
				item.Tag = new_car;
				update_item(item);
				listView1.Items.Add(item);
				this.car_count += 1;
				update_count();
			}
		}

		private void cars_add_car_event(car new_car)
		{
			ListViewItem item = new ListViewItem();
			item.Tag = new_car;
			update_item(item);
			listView1.Items.Add(item);
			this.car_count += 1;
			update_count();
		}

		private void cars_edit_car_event(car selected_car)
		{
			foreach(ListViewItem item in listView1.Items)
            {
				if (ReferenceEquals(item.Tag, selected_car))
				{
					update_item(item);
				}
			}
		}

		private void cars_delete_car_event(car selected_car)
		{
			foreach (ListViewItem item in listView1.Items)
			{
				if (ReferenceEquals(item.Tag, selected_car))
				{
					listView1.Items.Remove(item);
					this.car_count -= 1;
					update_count();
				}
			}
		}

		private void car_list_gui_Load(object sender, EventArgs e)
        {
			update_items();
			cars.add_car_event += cars_add_car_event;
			cars.update_car_event += cars_edit_car_event;
			cars.delete_car_event += cars_delete_car_event;
		}

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
			car_editor_gui car_form = new car_editor_gui(null, cars.cars);
			if (car_form.ShowDialog() == DialogResult.OK)
			{
				car new_car = new car(car_form.brand, car_form.max_speed, car_form.date_of_production, car_form.type);
				cars.add_car(new_car);
			}
		}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
			if (listView1.SelectedItems.Count != 1)
				return;
			car selected_car = (car)listView1.SelectedItems[0].Tag;
			car_editor_gui car_form = new car_editor_gui(selected_car, cars.cars);
			if (car_form.ShowDialog() == DialogResult.OK)
			{
				selected_car.edit(car_form.brand, car_form.max_speed, car_form.date_of_production, car_form.type);
				cars.update_car(selected_car);
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			car_editor_gui car_form = new car_editor_gui(null, cars.cars);
			if (car_form.ShowDialog() == DialogResult.OK)
			{
				car new_car = new car(car_form.brand, car_form.max_speed, car_form.date_of_production, car_form.type);
				cars.add_car(new_car);
			}
		}

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (listView1.SelectedItems.Count != 1)
				return;
			car selected_car = (car)listView1.SelectedItems[0].Tag;
			car_editor_gui car_form = new car_editor_gui(selected_car, cars.cars);
			if (car_form.ShowDialog() == DialogResult.OK)
			{
				selected_car.edit(car_form.brand, car_form.max_speed, car_form.date_of_production, car_form.type);
				cars.update_car(selected_car);
			}
		}

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
			if (listView1.SelectedItems.Count != 1)
				return;
			car selected_car = (car)listView1.SelectedItems[0].Tag;
			cars.delete_car(selected_car);
		}

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (listView1.SelectedItems.Count != 1)
				return;
			car selected_car = (car)listView1.SelectedItems[0].Tag;
			cars.delete_car(selected_car);
		}

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (toolStripComboBox1.Text == "All")
			{
				listView1.Items.Clear();
				car_count = 0;
				update_items();
				update_count();
			}
			else if (toolStripComboBox1.Text == "Max Speed >= 100km/h")
			{
				listView1.Items.Clear();
				car_count = 0;
				foreach (car new_car in cars.cars)
				{
					if(new_car.max_speed >= 100) 
					{
						ListViewItem item = new ListViewItem();
						item.Tag = new_car;
						update_item(item);
						listView1.Items.Add(item);
						this.car_count += 1;
					}
				}
				update_count();
			}
			else if (toolStripComboBox1.Text == "Max Speed < 100km/h")
			{
				listView1.Items.Clear();
				car_count = 0;
				foreach (car new_car in cars.cars)
				{
					if (new_car.max_speed < 100)
					{
						ListViewItem item = new ListViewItem();
						item.Tag = new_car;
						update_item(item);
						listView1.Items.Add(item);
						this.car_count += 1;
					}
				}
				update_count();
			}
		}

		private void update_command_availablility()
        {
			toolStripButton2.Enabled = listView1.SelectedItems.Count == 1;
			toolStripButton3.Enabled = listView1.SelectedItems.Count == 1;
			editToolStripMenuItem.Enabled = listView1.SelectedItems.Count == 1;
			deleteToolStripMenuItem.Enabled = listView1.SelectedItems.Count == 1;
		}

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
			update_command_availablility();
        }
    }
}
