using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Restaurant.Core.DataAccess.SqlServer
{
    public class SqlOrderRepository : SqlBaseRepository, IOrderRepository
    {
        public SqlOrderRepository(SqlContext contex) : base(contex)
        {

        }

        public int Add(Order order)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"insert into Orders output inserted.Id
                        values( @CustomerId,@CourierId, @Address, @Note, 
                        @CreatorId, @LastModifiedDate, @IsDeleted)";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, order);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        public Order FindById(int id)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"select m.*,
                           c.Id as CustomerId ,c.Id as CourierId, c.Name as CustomerName
                           from Orders as m
                           Inner Join Customers as c ON c.Id = m.CustomerId 
						   Inner Join Couriers as d ON d.Id = m.CourierId
                           where m.IsDeleted = 0 and m.Id = @Id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Order order = GetFromReader(reader);

                        return order;
                    }

                    return null;
                }
            }
        }

        public List<Order> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"select m.*,
                           c.Id as CustomerId ,c.Id as CourierId, c.Name as CustomerName
                           from Orders as m
                           Inner Join Customers as c ON c.Id = m.CustomerId 
						   Inner Join Couriers as d ON d.Id = m.CourierId
                           where m.IsDeleted = 0";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    List<Order> orders = new List<Order>();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = GetFromReader(reader);

                        orders.Add(order);
                    }

                    return orders;
                }
            }
        }

        public bool Update(Order order)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"update Orders set CustomerId = @CustomerId,CourierId=@CourierId, 
									Note = @Note, CreatorId = @CreatorId, 
                                  LastModifiedDate = @LastModifiedDate,
                                  IsDeleted = @IsDeleted where Id = @Id";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("@Id", order.Id);

                    AddParameters(command, order);

                    return command.ExecuteNonQuery() == 1;

                }
            }
        }

        private void AddParameters(SqlCommand command, Order order)
        {
            command.Parameters.AddWithValue("@CustomerId", order.Customer?.Id ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CourierId", order.Courier?.Id ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Address", order.Address);
            command.Parameters.AddWithValue("@Note", order.Note ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatorId", order.Creator.Id);
            command.Parameters.AddWithValue("@LastModifiedDate", order.LastModifiedDate);
            command.Parameters.AddWithValue("@IsDeleted", order.IsDeleted);
        }
        private Order GetFromReader(SqlDataReader reader)
        {
            Order order = new Order();

            order.Id = reader.GetInt32("Id");

            order.Customer = new Customer()
            {
                Id = reader.GetInt32("CustomerId"),
                Name = reader.GetString("CustomerName")
            };
            order.Courier = new Courier()
            {
                Id = reader.GetInt32("CourierId"),
                Name = reader.GetString("CourierId")
            };

            order.Address = reader.GetString("Address");


            if (!reader.IsDBNull("Note"))
            {
                order.Note = reader.GetString("Note");
            }

            return order;
        }
    }
}
    
