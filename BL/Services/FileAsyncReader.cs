using BL.Interfaces;
using BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class FileAsyncReader<T> : IFileAsyncReader<T>
    {
        public async Task<T> ReadFile(string path)
        {
            string fileContent = await File.ReadAllTextAsync(path);
            return JsonConvert.DeserializeObject<T>(fileContent);
        }
    }
}
