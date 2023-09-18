using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Item = StaticLibrary.Item;

namespace Knight.Model
{
    public class Food : Item
    {
        private int _satiety = 0;

        public int Satiety
        {
            get { return _satiety; }
            set { _satiety = value; }
        }

        public override string ToString()
        {
            string info = "";
            info += "\n   Еда:   " + Name;
            info += "\n   Описание:   " + Description;
            info += "\n   Вес:   " + Weight.ToString() + " кг.";
            info += "\n   Цена:   " + Price.ToString() + " тугр.";
            info += "\n   Сытность:   " + Satiety.ToString() + " ккал.";

            return info;
        }

        public override void Use()
        {   
            _satiety /= 2;
            _price /= 2;
            _weight /= 2;

            Console.WriteLine("Наполовину скушано...");
        }

        public override void Default()
        {
            base.Default();
            _satiety = 0;
        }

        public Food(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Init(float weight, float price, int satiety)
        {
            base.Init(weight, price);
            _satiety = satiety;
        }
    }
}
