using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Grammer.IssueTracking.WinForms.Interfaces;
using Grammer.IssueTracking.WinForms.Models;
using Grammer.IssueTracking.WinForms.Utilities;

namespace Grammer.IssueTracking.WinForms.Repositories
{
    public class IssueRepository : IGenericRepository<Issue>
    {
        private readonly string connectionString;

        public IssueRepository(IOptionsMonitor<ConnectionStringOptions> optionsMonitor)
        {
            connectionString = optionsMonitor.CurrentValue.DataAll;
        }

        public void Delete(Issue obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Issue> GetAll()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Issues;";

            var reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                yield break;
            }

            while (reader.Read())
            {
                yield return new Issue();
            }

            connection.Close();
        }

        public IEnumerable<Issue> GetAllByDepartmentId(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Issues WHERE DepartmentID = @id;";
            command.Parameters.AddWithValue("@id", id);

            var reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                yield break;
            }

            while (reader.Read())
            {
                yield return new Issue();
            }

            connection.Close();
        }

        public Issue GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Issue obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Issue obj)
        {
            throw new NotImplementedException();
        }
    }
}
