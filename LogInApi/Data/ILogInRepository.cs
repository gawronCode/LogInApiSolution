using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogInApi.Models;

namespace LogInApi.Data
{
    public interface ILogInRepository
    {

        public bool SaveChanges();
        public AppClient GetAppClientById(int id);
        public AppClient ValidateCredentials(AppClient client);
        public void CreateAppClient(AppClient client);
        public void UpdateCredentials(AppClient client);
        public void DeleteAppClient(AppClient client);


    }
}
