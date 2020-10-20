using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogInApi.Models;

namespace LogInApi.Data
{
    interface ILogInRepository
    {

        public bool SaveChanges();
        public IEnumerable<AppClient> GetAllAppClients();
        public AppClient GetAppClientById(int id);
        public string ValidateCredentials(int id);
        public void CreateAppClient(AppClient client);
        public void UpdateCredentials(AppClient client);
        public void DeleteAppClient(AppClient client);


    }
}
