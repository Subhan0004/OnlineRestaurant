using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DataAccess.SqlServer
{
    public class SqlCustomerRepository : SqlBaseRepository, ICustomerRepository
    {
        public SqlCustomerRepository(SqlContext context) : base(context)
        {

        }
       
        public int Add(Customer customer)
        {
            using(SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"Insert into Customers output inserted.id 
                                   values(@Name, @Surname, @Address, @Phone, 
                                   @Note, @CreatorId, @LastModifiedDate, @IsDeleted)";

                using(SqlCommand cmd = new SqlCommand(cmdText,connection))
                {
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Surname", customer.Surname);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@Note", customer.Note);
                    cmd.Parameters.AddWithValue("@CreatorId", customer.Creator.Id);
                    cmd.Parameters.AddWithValue("@LastModifiedDate", customer.LastModifiedDate);
                    cmd.Parameters.AddWithValue("@IsDeleted", customer.IsDeleted);


                    return (int)cmd.ExecuteScalar();

                }
            }
        }
    }
}
