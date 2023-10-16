using System;
using System.Runtime.Serialization;
using System.Windows.Media.Media3D;
using System.Text.Json.Serialization;

namespace StaticLibrary
{
    [Serializable]
    public class Food : Item
    {
        private int _satiety = 0;

        [JsonPropertyName("sat")]
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

        public Food() { }
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
