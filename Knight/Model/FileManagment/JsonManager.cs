﻿using StaticLibrary;
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
using System.Windows;

namespace Knight.Model.FileManagment
{
    public class JsonManager : IFileManager
    {
        public string Path { get; set; }
        private string _path;

        public JsonManager(string path) => _path = path;

        public Item Load()
        {
            var info = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<Item>(info);
        }

        public void Save(Item item)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            try
            {
                string json = JsonSerializer.Serialize<Item>(item, options);
                File.WriteAllText(_path, json);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Недопустимый тип");
            }
        }
    }
}
