using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm_CS
{
    class Airlines
    {
        private int id;
        private string name;
        private string airplane;
        private int seatsavailable;
        private string mealAvailable;

        public Airlines(int id, string name, string airplane, int seatsavailable, string mealAvailable)
        {
            Id = id;
            Name = name;
            Airplane = airplane;
            Seatsavailable = seatsavailable;
            MealAvailable = mealAvailable;
        }

        public Airlines()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Airplane { get => airplane; set => airplane = value; }
        public int Seatsavailable { get => seatsavailable; set => seatsavailable = value; }
        public string MealAvailable { get => mealAvailable; set => mealAvailable = value; }

        Queue<Airlines> airlinesData = new Queue<Airlines>();

        public void addairlinesData(Airlines airlines)
        {
            airlinesData.Enqueue(airlines);
        }

        public Queue<Airlines> getairlinesData()
        {
            Queue<Airlines> airlinesInfo = new Queue<Airlines>();

            foreach (var airline in airlinesData)
            {
                airlinesInfo.Enqueue(airline);
            }

            return airlinesInfo;
        }

        public void deleteairlinesData(int id, out Queue<Airlines> airlinesInfo)
        {
            airlinesInfo = new Queue<Airlines>(airlinesData.Where(x => x.Id != id));
        }
    }
}
