using BL.Interfaces;
using BL.Models;
using BL.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ProvidersService : IProvidersService
    {
        private IProvidersFetcher _providersFetcher;
        public ProvidersService(IProvidersFetcher providersFetcher)
        {
            _providersFetcher = providersFetcher;
        }
        public async Task<IEnumerable<Provider>> GetProviders(string specialty, long date, float score)
        {
            try
            {
                RulesHolder rulesHolder = new RulesHolder();
                rulesHolder.addSpecialtyRule(specialty);
                rulesHolder.addScoreRule(score);
                rulesHolder.addAvailabiltyRule(date);

                Provider[] providers = await _providersFetcher.FetchProviders();

                return providers.Where(provider => rulesHolder.ApplyAllRules(provider));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<string> SortProviders(IEnumerable<Provider> providers)
        {
            return providers.OrderByDescending(provider => provider.Score).Select(provider => provider.Name);
        }
        public async Task<bool> CanScheduleAppointment(string name,long date)
        {
            try
            {
                RulesHolder rulesHolder = new RulesHolder();
                rulesHolder.addNameRule(name);
                rulesHolder.addAvailabiltyRule(date);

                Provider[] providers = await _providersFetcher.FetchProviders();
                Provider toCheck = providers.FirstOrDefault(provider => rulesHolder.ApplyAllRules(provider));

                return toCheck == null ? false : true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
