using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Media3D;

namespace StaticLibrary
{
    public abstract class Item
    {
        public string Name
        {
            get { return _name; }
            set { if (value != "") _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { if (value != "") _description = value; }
        }
        public float Weight
        {
            get { return _weight; }
            set { if (value > 0) _weight = value; }
        }
        public float Price
        {
            get { return _price; }
            set { if (value >= 0) _price = value; }
        }

        protected float _weight = 0;
        protected float _price = 0;
        protected string _name = "Неизвестный предмет";
        protected string _description = "Только богам известно, на что он способен";

        public Item(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Init(float weight, float price)
        {
            _weight = weight;
            _price = price;
        }

        public Item()
        {

        }

        public virtual void Default()
        {
            _name = "Неизвестный предмет";
            _description = "Только богам известно, на что он способен";
            _weight = _price = 0;
        }

        public override string ToString()
        {
            string info = "";
            info += "\n   Предмет:   " + _name;
            info += "\n   Описание:   " + _description;
            info += "\n   Вес:   " + _weight.ToString() + " кг.";
            info += "\n   Цена:   " + _price.ToString() + " тугр.";

            return info;
        }

        public virtual void Use()
        {
            string message = "Ничего не произошло...";
            MessageBox.Show(message);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Description.GetHashCode() + Weight.GetHashCode() + Price.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }

}
