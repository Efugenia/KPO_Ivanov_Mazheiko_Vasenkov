using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaticLibrary
{
    [Serializable]
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
            string info = base.ToString();
            info += "\n" + (string)Application.Current.FindResource("damage") + ":   " + Damage.ToString()
                                                        + " " + (string)Application.Current.FindResource("damageUnit");
            return info;
        }

        public override void Default()
        {
            base.Default();
            _damage = 0;
        }

        public Weapon() { Type = "Weapon"; }

        public Weapon(string name, string description)
        {
            Name = name;
            Description = description;
            Type = "Weapon";
        }

        public Weapon(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
            _damage = info.GetInt32("Damage");
        }

        public void Init(float weight, float price, int damage)
        {
            base.Init(weight, price);
            _damage = damage;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Damage", _damage);
        }
    }
}
