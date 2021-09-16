using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Restaurant.Core.DataAccess.SqlServer
{
    public class SqlCourierRepository : SqlBaseRepository, ICourierRepository
    {
        public SqlCourierRepository(SqlContext context): base(context)
        {
            
        }
        public int Add(Courier courier)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"insert into Couriers output inserted.Id
                        values(@Name, @Surname, @Phone, @Note, 
                        @CreatorId, @LastModifiedDate, @IsDeleted)";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, courier);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        private void AddParameters(SqlCommand command, Courier courier)
        {
            command.Parameters.AddWithValue("@Name", courier.Name);
            command.Parameters.AddWithValue("@Surname", courier.Surname);
            command.Parameters.AddWithValue("@Phone", courier.Phone);
            command.Parameters.AddWithValue("@Note", courier.Note ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatorId", courier.Creator.Id);
            command.Parameters.AddWithValue("@LastModifiedDate", courier.LastModifiedDate);
            command.Parameters.AddWithValue("@IsDeleted", courier.IsDeleted);
        }

        public List<Courier> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"Select * from Couriers where IsDeleted = 0";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    List<Courier> couriers = new List<Courier>();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Courier courier = GetFromReader(reader);

                        couriers.Add(courier);
                    }

                    return couriers;
                }
            }
        }

        private Courier GetFromReader(SqlDataReader reader)
        {
            Courier courier = new Courier();

            courier.Id = reader.GetInt32("Id");
            courier.Name = reader.GetString("Name");
            courier.Surname = reader.GetString("Surname");
            courier.Phone = reader.GetString("Phone");

            if (!reader.IsDBNull("Note"))
            {
                courier.Note = reader.GetString("Note");
            }

            return courier;
        }

        public bool Update(Courier courier)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"update Couriers set Name = @Name, Surname = @Surname, 
                                  Phone = @Phone, Note = @Note, CreatorId = @CreatorId, 
                                  LastModifiedDate = @LastModifiedDate,
                                  IsDeleted = @IsDeleted where Id = @Id";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("@Id", courier.Id);

                    AddParameters(command, courier);

                    return command.ExecuteNonQuery() == 1;

                }
            }
        }
    }
}
