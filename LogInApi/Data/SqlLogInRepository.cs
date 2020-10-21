using LogInApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogInApi.Data
{
    public class SqlLogInRepository : ILogInRepository
    {
        private readonly AppClientContext _context;

        public SqlLogInRepository(AppClientContext context)
        {
            _context = context;
        }

        public void CreateAppClient(AppClient client)
        {
            if(client is null) throw new ArgumentNullException(nameof(client));
            _context.AppClientItems.Add(client);
        }

        public void DeleteAppClient(AppClient client)
        {
            if(client is null) throw new ArgumentNullException(nameof(client));
            _context.AppClientItems.Remove(client);
        }

        public IEnumerable<AppClient> GetAllAppClients()
        {
            return _context.AppClientItems.ToList();
        }

        public AppClient GetAppClientById(int id)
        {
            return _context.AppClientItems.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCredentials(AppClient client)
        {
            
        }

        public AppClient ValidateCredentials(AppClient client)
        {
            return _context.AppClientItems.FirstOrDefault(p => p.Nick == client.Nick && p.PassCode == client.PassCode);
        }
    }
}
