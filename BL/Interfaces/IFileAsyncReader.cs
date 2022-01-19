using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IFileAsyncReader<T>
    {
        Task<T> ReadFile(string path);
    }
}
