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
        private readonly RepositoryContext _repositoryContext;

        public KnihaRepository(ILogger<KnihaRepository> logger, RepositoryContext repositoryContext)
        {
            _logger = logger;
            _repositoryContext = repositoryContext;
        }

        public void Delete(Kniha obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kniha> GetAll()
        {
            // Using DB Context
            using var context = _repositoryContext;
            
            // Body
            var knihy = context.Set<Kniha>();
            foreach (var item in knihy)
            {
                _logger.LogInformation($"{item.KnihaId}");
                yield return item;
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
