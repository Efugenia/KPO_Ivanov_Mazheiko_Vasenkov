using System;
using System.Runtime.Serialization;
using System.Windows.Media.Media3D;
using System.Text.Json.Serialization;
using System.Windows;

namespace StaticLibrary
{
    [Serializable]
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
            string info = base.ToString();
            info += $"\n{Application.Current.FindResource("satiety")}:   {Satiety} " +
                         $"{Application.Current.FindResource("satietyUnit")}";

            return info;
        }

        public override void Default()
        {
            base.Default();
            _satiety = 0;
        }

        public Food() { Type = "Food"; }
        public Food(string name, string description)
        {
            Name = name;
            Description = description;
            Type = "Food";
        }
        public Food(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _satiety = (int)info.GetValue("Satiety",typeof(int));
        }

        //public Food(string name, string description, float weight, float price, int satiety)
        //{
        //    _name = name;
        //    _description = description;
        //    _weight = weight;
        //    _price = price;
        //    _satiety = satiety;
        //}

        public void Init(float weight, float price, int satiety)
        {
            base.Init(weight, price);
            _satiety = satiety;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Satiety", _satiety);
        }
    }
}
