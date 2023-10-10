using Application.Infrastructure;
using Microsoft.VisualBasic;
using Shared.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class AccessTokenRepository
    {
        SQLiteAsyncConnection Database;
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DbContext.DatabasePath, DbContext.Flags);
            var result = await Database.CreateTableAsync<AccessToken>();
        }
        public async Task<string> GetAccessToken()
        {
            try
            {
                await Init();
                var _token = await Database.Table<AccessToken>().ToListAsync();

                if (_token.Count == 0) return "";

                return _token.First().Token;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public async Task SetAccessToken(AccessToken token)
        {
            await Init();
            if (token.Id != default)
                await Database.UpdateAsync(token);
            else
                await Database.InsertAsync(token);
        }
        public async Task<bool> AnyAccessToken(AccessToken token)
        {
            await Init();
            var list = await Database.Table<AccessToken>().ToListAsync();
            return list.Any();
        }
        public async Task RemoveAccessToken()
        {
            await Init();
            var _token = await Database.Table<AccessToken>().FirstAsync();
            await Database.DeleteAsync(_token);
        }
    }
}
