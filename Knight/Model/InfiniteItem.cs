using StaticLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight.Model
{
    [Serializable]

    internal class InfiniteItem: EnchantedItem
    {
        public InfiniteItem(Item item, string description) : base(item, description + "\n ~ НЕРУШИМЫЙ ~ ")
        {
            base.Init(item.Weight, item.Price);
        }

        
    }
}
