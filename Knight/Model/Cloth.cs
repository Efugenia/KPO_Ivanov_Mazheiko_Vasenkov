using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Item = StaticLibrary.Item;

namespace Knight.Model
{
    public class Cloth : Item
    {   
        private string _material = "Неизвестный материал";

        public string Material
        {
            get { return _material; }
            set { _material = value; }
        }

        public override string ToString()
        {
            string info = "";
            info += "\n   Одежда:   " + Name;
            info += "\n   Описание:   " + Description;
            info += "\n   Вес:   " + Weight.ToString() + " кг.";
            info += "\n   Цена:   " + Price.ToString() + " тугр.";
            info += "\n   Материал:   " + Material.ToString();

            return info;
        }

        public override void Use()
        {
            Console.WriteLine($"Вы надели {Name}");
        }

        public override void Default()
        {
            base.Default();
            _material = "Неизвестный материал";
        }

        public Cloth(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Init(float weight, float price, string material)
        {
            base.Init(weight, price);
            _material = material;
        }
    }
}
