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
    public class FileProvidersFetcher : IProvidersFetcher
    {
        private IFileAsyncReader<Provider[]> FileReader {get;set;}
        public FileProvidersFetcher(IFileAsyncReader<Provider[]> fileReader)
        {
            FileReader = fileReader;
        }
        public Task<Provider[]> FetchProviders()
        {
            try
            {
                return FileReader.ReadFile("./providers.json");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
