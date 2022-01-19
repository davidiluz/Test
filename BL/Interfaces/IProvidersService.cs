using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IProvidersService
    {
        Task<IEnumerable<Provider>> GetProviders(string specialty, long date, float score);
        IEnumerable<string> SortProviders(IEnumerable<Provider> providers);

        Task<bool> CanScheduleAppointment(string name, long date);
    }
}
