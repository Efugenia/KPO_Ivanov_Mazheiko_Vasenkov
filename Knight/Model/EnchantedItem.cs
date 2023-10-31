using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Item = StaticLibrary.Item;
using Food = StaticLibrary.Food;
using Weapon = StaticLibrary.Weapon;
using Cloth = StaticLibrary.Cloth;

namespace Knight.Model
{
    [Serializable]
    internal class EnchantedItem : StaticLibrary.Item
    {
        protected Item item;
        public Dictionary<string, object> Attributes = new Dictionary<string, object>();

        public EnchantedItem(Item item, string description) : base(item.Name, description)
        {
            this.item = item;

            PropertyInfo[] properties = item.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Attributes[property.Name] = property.GetValue(item);
            }
        }

        public string GetAttribute()
        {
            string description = "";
            foreach (var attribute in Attributes)
            {
                description += attribute.ToString() + "\n";
            }

            return description;
        }
    }
}
