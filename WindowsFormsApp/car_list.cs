using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class car_list
    {
        public List<car> cars = new List<car>();

        public event Action<car> add_car_event, delete_car_event;
        public event Action<car, car> update_car_event;

        public void add_car(car car1)
        {
            cars.Add(car1);
            add_car_event?.Invoke(car1);
        }

        public void update_car(car car1, car car2)
        {
            int i = cars.IndexOf(car1);
            cars[i] = car2;
            update_car_event?.Invoke(car1, car2);
        }

        public void delete_car(car car1)
        {
            cars.Remove(car1);
            delete_car_event?.Invoke(car1);
        }
    }
}
