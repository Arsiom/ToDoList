using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.models;

namespace WPF.Services
{
    internal class IO
    {
        private readonly string PATH;

        public IO(string path)
        {
            PATH = path;
        }
        public BindingList<ToDoModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if(!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
            }
        }
        public void SaveData(object _todoDateList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(_todoDateList);
                writer.WriteLine(output);
            }
        }
    }
}
