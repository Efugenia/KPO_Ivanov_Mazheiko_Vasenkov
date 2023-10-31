using StaticLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Knight.Model
{
    [Serializable]

    internal class FeatherlikeItem: EnchantedItem
    {
        public FeatherlikeItem(Item item, string description) : base(item, description + $"\n {Application.Current.FindResource("lightnessEffect")} ")
        {
            item.Weight = 1;
            base.Init(item.Weight, item.Price);
        }
    }
}
