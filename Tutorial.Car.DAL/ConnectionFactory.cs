using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using Tutorial.Car.Common;

namespace Tutorial.Car.DAL
{
    public interface IConnectionFactory
	{
		SqlConnection GetOpenedConnection();
	}
	public class ConnectionFactory : IConnectionFactory
	{
		private readonly string _connectionString;

		public ConnectionFactory(IOptions<AppSettings> appSettings)
		{
			_connectionString = appSettings.Value.ConnectionString;
		}

		public SqlConnection GetOpenedConnection()
		{
			Func<string, SqlConnection> getConnection = x =>
			{
				switch (x)
				{
					case "Dev": return new SqlConnection(_connectionString);
					default:
						return new SqlConnection(_connectionString);
				}
			};

			var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			var connection = getConnection(env);
			connection.Open();
			return connection;
		}


	}
}
