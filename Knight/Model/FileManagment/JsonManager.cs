using StaticLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Knight.Model.FileManagment
{
    public class JsonManager : IFileManager
    {
        public string Path { get; set; }
        private string _path;

        public JsonManager(string path) => _path = path;

        public Item Load()
        {
            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Item));
            //Stream stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
            var info = File.ReadAllText(_path);
            
            //var item = (Item)serializer.ReadObject(stream);
            //stream.Close();
            return JsonSerializer.Deserialize<Item>(info);
        }

        public void Save(Item item)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize<Item>(item, options);
            File.WriteAllText(_path, json);
            //var asas = item.GetType();
            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            //Stream stream = new FileStream(_path, FileMode.Create);
            //serializer.WriteObject(stream, item);
            //stream.Close();
        }
    }
}
