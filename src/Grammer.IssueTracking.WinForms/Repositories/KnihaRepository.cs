using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammer.IssueTracking.WinForms.Interfaces;
using Grammer.IssueTracking.WinForms.Models;
using Grammer.IssueTracking.WinForms.Utilities;

namespace Grammer.IssueTracking.WinForms.Repositories
{
    public class KnihaRepository : IGenericRepository<Kniha>
    {
        private readonly ILogger<KnihaRepository> logger;
        private readonly string connectionString;

        public KnihaRepository(ILogger<KnihaRepository> logger, IOptionsMonitor<ConnectionStringOptions> optionsMonitor)
        {
            this.logger = logger;
            connectionString = optionsMonitor.CurrentValue.DataAll;
        }

        public void Delete(Kniha obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kniha> GetAll()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new RepositoryContext(optionsBuilder.Options)) 
            {
                var knihy = context.Set<Kniha>();
                foreach (var item in knihy)
                {
                    logger.LogInformation($"{item.ID}");
                    yield return item;
                }
            }
        }

        public Kniha GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Kniha obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Kniha obj)
        {
            throw new NotImplementedException();
        }
    }
}
