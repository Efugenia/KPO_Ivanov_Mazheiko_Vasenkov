using StaticLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable SYSLIB0011
#pragma warning disable SYSLIB00

namespace Knight.Model.FileManagment
{
    public class BinaryManager : IFileManager
    {
        public string Path { get; set; }
        private string _path;

        public BinaryManager(string path) => _path = path;

        public Item Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                return (Item)formatter.Deserialize(fs);
            }
        }

        public void Save(Item item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
