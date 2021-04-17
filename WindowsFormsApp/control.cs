using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WindowsFormsApp
{
    public class control : PictureBox
    {

        private System.ComponentModel.IContainer components = null;

        [BrowsableAttribute(true)]
        [EditorAttribute(typeof(car_type_editor), typeof(UITypeEditor))]
        public int car_type = 0;

        public Dictionary<string, int> string_to_index = new Dictionary<string, int>();

        public Dictionary<int, string> index_to_string = new Dictionary<int, string>();

        public List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>(new System.Drawing.Bitmap[]
        {
            global::WindowsFormsApp.Properties.Resources.sports_car,
            global::WindowsFormsApp.Properties.Resources.passenger_car,
            global::WindowsFormsApp.Properties.Resources.truck
        });

        public control()
        {
            InitializeComponent();
            Image = images[car_type];
            string_to_index["sports_car"] = 0;
            string_to_index["passenger_car"] = 1;
            string_to_index["truck"] = 2;
            index_to_string[0] = "sports_car";
            index_to_string[1] = "passenger_car";
            index_to_string[2] = "truck";
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


    public class car_type_editor : UITypeEditor
    {
        //public override void PaintValue(PaintValueEventArgs e)
        //{
        //    e.Graphics.DrawImage();
        //}

        //public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        //{
        //    return true;
        //}

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                control car_type = new control();
                edSvc.DropDownControl(car_type);

                return car_type.car_type;
            }
            return value;
        }
    }
}
