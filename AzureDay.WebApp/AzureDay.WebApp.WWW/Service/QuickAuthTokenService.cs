using AzureDay.WebApp.Config;
using AzureDay.WebApp.Database;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.WWW.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDay.WebApp.WWW.Service
{
    public sealed class QuickAuthTokenService
    {
        public async Task<QuickAuthToken> GetQuickAuthTokenByValueAsync(string token, bool? isUsed = null)
        {
            var authToken = await DataFactory.QuickAuthTokenService.Value.GetByKeysAsync(Configuration.Year, token);

            if (isUsed.HasValue)
            {
                if (authToken.IsUsed == isUsed.Value)
                {
                    return AppFactory.Mapper.Value.Map<QuickAuthToken>(authToken);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return AppFactory.Mapper.Value.Map<QuickAuthToken>(authToken);
            }
        }

        public async Task ExpireTokenByValueAsync(string token)
        {
            var authToken = await DataFactory.QuickAuthTokenService.Value.GetByKeysAsync(Configuration.Year, token);

            if (authToken != null)
            {
                authToken.IsUsed = true;
                await DataFactory.QuickAuthTokenService.Value.ReplaceAsync(authToken);
            }
        }

        public async Task<bool> IsTokenValidForEmailAsync(string token, string email)
        {
            var authToken = await GetQuickAuthTokenByValueAsync(token, false);
            return authToken != null && authToken.Email == email;
        }

        public async Task AddQuickAuthTokenAsync(QuickAuthToken token)
        {
            var authToken = AppFactory.Mapper.Value.Map<Database.Entities.Table.QuickAuthToken>(token);
            await DataFactory.QuickAuthTokenService.Value.InsertAsync(authToken);
        }
    }
}
