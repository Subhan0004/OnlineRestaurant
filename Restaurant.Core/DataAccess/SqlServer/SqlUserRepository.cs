using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Core.Extensions;

namespace Restaurant.Core.DataAccess.SqlServer
{
    public class SqlUserRepository : BaseRepository, IUserRepository
    {
        public SqlUserRepository(SqlContext context) : base(context)
        {

        }

        public User Get(string username)
        {
            using(SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"select * from Users
                                  where Username=@username and IsDeleted = 0";
                
                using(SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        User user = new User();

                        user.Id = reader.GetInt32("Id");
                        user.Username = reader.GetString("Username");
                        user.Password = reader.GetString("Password");
                        user.CanOperateCrm = reader.GetBoolean("CanOperateCrm");
                       
                        if (!reader.IsDBNull("CreatorId"))
                        {
                            user.Creator = new User()
                            {
                                Id = Convert.ToInt32(reader["CreatorId"])
                            };
                        }
                        user.LastModifiedDate = reader.GetDateTime("LastModifiedDate");
                        user.IsDeleted = reader.GetBoolean("IsDeleted");
                        
                        return user;
                    }
                    
                    return null;
                }
                               
            }
        }
    }
}
