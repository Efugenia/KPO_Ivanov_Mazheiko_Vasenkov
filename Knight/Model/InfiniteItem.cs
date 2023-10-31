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

    internal class InfiniteItem: EnchantedItem
    {
        public InfiniteItem(Item item, string description) : base(item, description + $"\n {Application.Current.FindResource("infinityEffect")} ")
        {
            base.Init(item.Weight, item.Price);
        }

        
    }
}
