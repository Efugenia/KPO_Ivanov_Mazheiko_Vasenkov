using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace StaticLibrary
{
    [Serializable]
    [JsonDerivedType(typeof(Item), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(Food), typeDiscriminator: "food")]
    [JsonDerivedType(typeof(Cloth), typeDiscriminator: "cloth")]
    [JsonDerivedType(typeof(Weapon), typeDiscriminator: "weapon")]

    public class Item
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
        public string Type;

        protected float _weight;
        protected float _price;
        protected string _name;
        protected string _description;

        public Item(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public Item(SerializationInfo info, StreamingContext context)
        {
            _name = (string)info.GetValue("Name", typeof(string));
            _description = (string)info.GetValue("Description",typeof(string));
            _price = (float)info.GetValue("Price", typeof(float));
            _weight = (float)info.GetValue("Weight", typeof(float));
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
            _name = "����������� �������";
            _description = "������ ����� ��������, �� ��� �� ��������";
            _weight = _price = 0;
        }

        public override string ToString()
        {
            string info = "";
            info += "\n   �������:   " + _name;
            info += "\n   ��������:   " + _description;
            info += "\n   ���:   " + _weight.ToString() + " ��.";
            info += "\n   ����:   " + _price.ToString() + " ����.";

            return info;
        }

        public virtual void Use()
        {
            string message = "������ �� ���������...";
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

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(this.GetType());
            info.AddValue("__type",this.GetType());
            info.AddValue("Name", _name);
            info.AddValue("Description", _description);
            info.AddValue("Weight", _weight);
            info.AddValue("Price", _price);
        }

        public void SetObjectData(SerializationInfo info, StreamingContext context)
        {
            _name = (string)info.GetValue("���", typeof(string));
            _description = (string)info.GetValue("��������", typeof(string));
            _price = (float)info.GetValue("����", typeof(float));
            _weight = (float)info.GetValue("���", typeof(float));
        }
    }

}
