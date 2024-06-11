using System;
namespace Design_Patterns.Creational.FactoryPattern
{
    
   
    interface IDatabaseConnection
    {
        void Connect();
    }


    class SqlConnection : IDatabaseConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to SQL Server database...");
            
        }
    }

    
    class MySqlConnection : IDatabaseConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to MySQL database...");
            
        }
    }

    
    class PostgreSqlConnection : IDatabaseConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to PostgreSQL database...");
            
        }
    }

    // Factory interface
    interface IDatabaseConnectionFactory
    {
        IDatabaseConnection CreateConnection(DatabaseType type);
    }

    // Concrete factory: Database Connection Factory
    class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        public IDatabaseConnection CreateConnection(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.SqlServer:
                    return new SqlConnection();
                case DatabaseType.MySQL:
                    return new MySqlConnection();
                case DatabaseType.PostgreSQL:
                    return new PostgreSqlConnection();
                default:
                    throw new NotSupportedException($"Database type '{type}' is not supported.");
            }
        }
    }

    // Enum for supported database types
    enum DatabaseType
    {
        SqlServer,
        MySQL,
        PostgreSQL
    }

    // Client code
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IDatabaseConnectionFactory factory = new DatabaseConnectionFactory();

    //        // Create SQL Server connection
    //        IDatabaseConnection sqlConnection = factory.CreateConnection(DatabaseType.SqlServer);
    //        sqlConnection.Connect();

    //        // Create MySQL connection
    //        IDatabaseConnection mySqlConnection = factory.CreateConnection(DatabaseType.MySQL);
    //        mySqlConnection.Connect();

    //        // Create PostgreSQL connection
    //        IDatabaseConnection postgreSqlConnection = factory.CreateConnection(DatabaseType.PostgreSQL);
    //        postgreSqlConnection.Connect();
    //    }
    //}

}

