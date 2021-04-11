using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class car
    {
        public string brand
        {
            get;
            set;
        }

        public int max_speed
        {
            get;
            set;
        }

        public DateTime date_of_producion
        {
            get;
            set;
        }

        public string type
        {
            get;
            set;
        }

        public car(string brand, int max_speed, DateTime date_of_producion, string type)
        {
            this.brand = brand;
            this.max_speed = max_speed;
            this.date_of_producion = date_of_producion;
            this.type = type;
        }
    }
}
