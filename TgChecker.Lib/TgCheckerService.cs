using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using WTelegram;

namespace TgChecker.Lib
{
    public class TgCheckerService
    {
        public event Func<string> GetVerificationCode;

        private Client client;
        private User currentUser;

        private string phoneNumber;
        private string? password;

        private readonly IConfiguration _configuration;
        private readonly EfSQLiteDbContext _dbContext;

        public TgCheckerService(IConfiguration configuration, EfSQLiteDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public void ListenTgAccount(string phoneNumber, string? password = null)
        {
            this.phoneNumber = phoneNumber;
            this.password = password;

            client = new Client(GetWTelegramConfiguration);

            long count = 1;
            client.OnUpdate += async (updates) => { Console.WriteLine($"New event!#{count++}"); /*save events to data.db file*/ };

            var task = client.LoginUserIfNeeded();
            task.Wait();
            currentUser = task.Result;
        }

        private string GetWTelegramConfiguration(string key)
        {
            switch (key)
            {
                case "api_id":
                    {
                        return _configuration.GetValue<string>("WTelegram:apiId")!;
                    }
                case "api_hash":
                    {
                        return _configuration.GetValue<string>("WTelegram:apiHash")!;
                    }
                case "phone_number":
                    {
                        return phoneNumber;
                    }
                case "verification_code":
                    {
                        return GetVerificationCode.Invoke();
                    }
                case "password":
                    {
                        return password!;
                    }
                default:
                    {
                        return null!;
                    }
            }
        }
    }
}
