using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Music.WindowsStore.Model
{
    public class InformationProvider
    {
        public static async Task<IEnumerable<Method>> GetMethods()
        {
            //await Task.Factory.StartNew(() =>
            //{
            //    for (int i = 0; i < 100000; i++)
            //    {
            //        Debug.WriteLine(i);
            //    }
            //});
            return await GetJsonObject<IEnumerable<Method>>("methods.json");
        }
        public static async Task<Lesson> GetLesson(string filename)
        {
            return await GetJsonObject<Lesson>(filename);
        }
        public static async Task<T> GetJsonObject<T>(string filename) 
        {
            var folder = Package.Current.InstalledLocation;
            folder = await folder.GetFolderAsync("JsonFiles");
            var file = await folder.GetFileAsync(filename);
            var json = await Windows.Storage.FileIO.ReadTextAsync(file);
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}
