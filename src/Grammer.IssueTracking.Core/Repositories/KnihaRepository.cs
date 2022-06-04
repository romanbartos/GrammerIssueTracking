using System;
using System.Collections.Generic;
using Grammer.IssueTracking.Core.Interfaces;
using Grammer.IssueTracking.Core.Models;
using Grammer.IssueTracking.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Grammer.IssueTracking.Core.Repositories
{
    public class KnihaRepository : IGenericRepository<Kniha>
    {
        private readonly ILogger<KnihaRepository> _logger;
        private readonly string _connectionString;

        public KnihaRepository(ILogger<KnihaRepository> logger, IOptionsMonitor<ConnectionStringOptions> optionsMonitor)
        {
            _logger = logger;
            _connectionString = optionsMonitor.CurrentValue.DataAll;
        }

        public void Delete(Kniha obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kniha> GetAll()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            using (var context = new RepositoryContext(optionsBuilder.Options)) 
            {
                var knihy = context.Set<Kniha>();
                foreach (var item in knihy)
                {
                    _logger.LogInformation($"{item.KnihaId}");
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
