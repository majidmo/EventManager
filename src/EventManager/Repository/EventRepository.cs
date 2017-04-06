using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Models;

namespace EventManager.Repository
{
    public class EventRepository : IRepository<Event>
    {
        private string connectionString;
        public EventRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        
        public IEnumerable<Event> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Event>("SELECT [EventId],[Name],[Location],[Date],[Host], MaxNoOfAttendees FROM Events");
            }
        }

        public Event FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Event>("SELECT * FROM Events WHERE [EventId] = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Add(Event item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Events (Name,Location,Date,Host,MaxNoOfAttendees) VALUES(@Name,@Location,@Date,@Host, @MaxNoOfAttendees)", item);
            }

        }

        public void Update(Event item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Events SET Name = @Name,  Location  = @Location, Date= @Date, Host= @Host, MaxNoOfAttendees=@MaxNoOfAttendees WHERE EventId = @EventId", item);
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Events WHERE EventId=@Id", new { Id = id });
            }
        }
    }
}
