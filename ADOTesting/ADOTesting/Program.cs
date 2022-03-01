using System.Data;
namespace ADOTesting
{
    class Program
    {
        static void Main()
        {
            // INTERFACES exposed by ADO.NET
            // IdbConnection
            System.Data.IDbConnection conn;
            //conn = new someClassThatImplementsIdbConnection();
            //  What is the class
            //      Called database provider
            //          the only one you have to pick is the connection
            //              so what is a database provider
            //                  particular implementation of database
            //                      MySQL
            //                      SQLLite
            //                      SQLServer
            //  this is the Main decision that you have to make! ypu have to decide your database vendor!
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = "Server=localhost;Database=adn103movies;uid=root;";     // first you must set the connection string, this is a character strintg that tells to the SQL provider how to find the DB
            // this 3 lines of code are the minimun config required to set a database connection (basically choose the DB provider and the location of the database)

            // 2 properties that you must know about cdb connecttions are:
            //      ConnectingString
            //      State
            //System.Data.ConnectionState.Open    //is usefull if you need to tell the system to check the state and what to do with the different states of the connections (Open, Connecting, Broken, Closed, Fetching)

            conn.Open();

            IDbCommand Comm;
            //// bad example  :   HARD CODING:    the provider is specified All over the place in your code
            // Comm = new MySql.Data.MySqlClient.MySqlCommand();

            //// GOOD EXAMPLE : The selection as to your provider is ONLY made by the connection
            Comm = conn.CreateCommand();
            // command properties that are used
            // Comm.CommandText = ""; // Is going to be interpreted based on the CommandType if no CommandType is set it will be interpreted that the CommandType is set to as Text
            //Comm.CommandText = "SELECT * FROM movies";
            //Comm.CommandText = "SELECT count(*) FROM movies";
            //Comm.CommandText = "SELECT count(*) FROM movies WHERE minutes < @p_minutes"; //Where minutes < P_minutes
            Comm.CommandText = "SELECT Hours,Title,Minutes,hours*60+minutes as length FROM movies WHERE minutes < @p_minutes order by title";
            //Comm.CommandText = "SELECT * FROM movies WHERE minutes < P_minutes";
            Comm.CommandType = CommandType.Text;
            IDbDataParameter p1 = Comm.CreateParameter();
            p1.ParameterName = "@P_minutes";
            //p1.ParameterName = 'P_minutes';
            p1.Direction = ParameterDirection.Input;
            p1.Value = 45;
            p1.DbType = DbType.Int32;
            Comm.Parameters.Add(p1);

            // step 1: congigure the command text
            // step 2: configure the command type: either text, storedprocedure or tabledirect
            // step 3: create, configure and add ALL of the paramenters in the command (may have zero, one or many)

            // step 4: Execute the Command usign one of the three mechanisms
            // Comm.ExecuteNonQuery();  // When you are not epecting anything to come back
            //EXAMPLE == // int code = Comm.ExecuteNonQuey();

            // Comm.ExecuteScalar();    // When you are expecting only one value to come back (not a record)
            //EXAMPLE == // object answer = Comm.ExecuteScalar();

            // Comm.ExecuteReader();    // When you expect a bunch of records to come back == this is returning all of the data that is comming back from the server
            //EXAMPLE == // IDataReader reader = Comm.ExecuteReader();
            //IDataReader is a 'cursor' giving us READ-ONLY FORWARD ONLY access to our records
            IDataReader reader = Comm.ExecuteReader();

            //Console.WriteLine(Comm.ExecuteScalar());
            Console.WriteLine($"Field count: {reader.FieldCount}");
            for(int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine($"i:{i} {reader.GetName(i)}");
            }

            MovieMapper mapper = new MovieMapper(reader);
            //List<Movie>;

            while(reader.Read())
            {
                //for(int i = 0; i < reader.FieldCount; i++)
                //{
                    // while the [] indexet is flexible, it is very inefficient
                    //Console.WriteLine($"Name:{reader.GetName(i),15} {reader[i],25}");

                    
                    // The Get1XXX methods are significantly faster than the indexing [] technique
                    

                    //int hours = reader.GetInt32(0);
                    //hours = (int)reader["Hours"];
                    //string title = reader.GetString(1);
                    //title = (string)reader["Title"];
                    //int minutes = reader.GetInt32(2);
                    //int length = reader.GetInt32(3);

                    //Console.WriteLine($"hours: {hours,5} title:{title,35} minutes:{minutes,5} length:{length,5}");

                    //Movie m = new Movie();
               
                //m.Id = reader.GetInt32(0);
                //m.Title = reader.GetString(1);
                //m.Released = reader.GetDateTime(2);
                //m.Hours = reader.GetInt32(3);

                Movie m = mapper.MapMovie(reader);
                result.Add(m);
                movies.Add(m.Id, m);

          
                //}
                //Console.WriteLine();

            }
            reader.Close();

            foreach(Movie m in result)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine("**************************");
            foreach(Movie m in result)
            {
                Console.WriteLine(m);
            }
        } 

    }
}