using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Item = StaticLibrary.Item;
using Food = StaticLibrary.Food;
using Weapon = StaticLibrary.Weapon;
using Cloth = StaticLibrary.Cloth;

namespace Knight.Model
{
    [Serializable]

    internal class GoldenItem : EnchantedItem
    {
        public GoldenItem(Item item, string description) : base(item, description + "\n ~ ПОЗОЛОЧЕННЫЙ ~ ")
        {   
            if (item.Price == 0)
            {
                item.Price = 1;
            }
            item.Price *= 100;
            base.Init(item.Weight, item.Price);
        }
    }
}
