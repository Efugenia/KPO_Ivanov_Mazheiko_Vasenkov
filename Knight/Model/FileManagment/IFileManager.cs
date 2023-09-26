using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item = StaticLibrary.Item;
using Food = StaticLibrary.Food;
using Weapon = StaticLibrary.Weapon;
using Cloth = StaticLibrary.Cloth;

namespace Knight.Model.FileManagment
{
    public interface IFileManager
    {
        string Path { get; set; }

        public void Save(Item item);
        public Item Load();
    }
}
