using lab7.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7.Services
{
    class FileIOServices
    {
        private readonly string Path;

        public FileIOServices(string path)
        {
            Path = path;
        }
        public BindingList<TodoModels> LoadData()
        {
            var fileExists = File.Exists(Path);
            if (fileExists)
            {
                File.CreateText(Path).Dispose();
                return new BindingList<TodoModels>();
            }
            using (var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TodoModels>>(fileText);
            }
        }

        public void SaveData(object todoData)
        {
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(todoData);
                writer.Write(output);
            }
        }
    }
}
