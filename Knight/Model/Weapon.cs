using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Item = StaticLibrary.Item;

namespace Knight.Model
{
    public class Weapon: Item
    {
        private double _damage = 0;

        public double Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public override string ToString()
        {
            string info = "";
            info += "\n   Оружие:   " + Name;
            info += "\n   Описание:   " + Description;
            info += "\n   Вес:   " + Weight.ToString() + " кг.";
            info += "\n   Цена:   " + Price.ToString() + " тугр.";
            info += "\n   Урон:   " + Damage.ToString() + " ед.";

            return info;
        }

        public override void Use()
        {
            _damage -= 0.01 * _damage;
            Console.WriteLine("Вы совершили мастерский взмах мечом!");
        }

        public override void Default()
        {
            base.Default();
            _damage = 0;
        }

        public Weapon(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Init(float weight, float price, int damage)
        {
            base.Init(weight, price);
            _damage = damage;
        }
    }
}
