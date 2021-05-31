using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Restaurant.Core.DataAccess.SqlServer
{
    public class SqlMealRepository : SqlBaseRepository, IMealRepository
    {
        public SqlMealRepository(SqlContext contex) : base(contex)
        {

        }

        public int Add(Meal meal)
        {
           using(SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"insert into Meal output inserted.Id
                        values( @CategoriesId, @Name, @Price, @Quantity, @Note, 
                        @CreatorId, @LastModifiedDate, @IsDeleted)";

                using(SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, meal);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        public List<Meal> Get()
        {
            using(SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"select m.*,
                           c.Id as CategoriesId, c.Name as CategoryName
                           from Meal as m
                           Inner Join Categories as c ON c.Id = m.CategoriesId where m.IsDeleted = 0";

                using(SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    List<Meal> meals = new List<Meal>();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Meal meal = GetFromReader(reader);

                        meals.Add(meal);
                    }

                    return meals;
                }
            }
        }

        public Meal FindById(int id)
        {
            using(SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"select m.*,
                           c.Id as CategoriesId, c.Name as CategoryName
                           from Meal as m
                           Inner Join Categories as c ON c.Id = m.CategoriesId 
                           where m.IsDeleted = 0 and m.Id = @Id";
                using (SqlCommand command = new SqlCommand(cmdText,connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Meal meal = GetFromReader(reader);

                        return meal;
                    }

                    return null;
                }
            }
        }

        public bool Update(Meal meal)
        {
            using(SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"update Meal set CategoriesId = @CategoriesId, Name = @Name, Price = @Price, 
                                  Quantity = @Quantity, Note = @Note, CreatorId = @CreatorId, 
                                  LastModifiedDate = @LastModifiedDate,
                                  IsDeleted = @IsDeleted where Id = @Id";
                
                using(SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("@Id", meal.Id);

                    AddParameters(command, meal);

                    return command.ExecuteNonQuery() == 1;

                }
            }
        }

        private void AddParameters(SqlCommand command, Meal meal)
        {
            command.Parameters.AddWithValue("@CategoriesId", meal.Category?.Id ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Name", meal.Name);
            command.Parameters.AddWithValue("@Price", meal.Price);
            command.Parameters.AddWithValue("@Quantity", meal.Quantity);
            command.Parameters.AddWithValue("@Note", meal.Note ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatorId", meal.Creator.Id);
            command.Parameters.AddWithValue("@LastModifiedDate", meal.LastModifiedDate);
            command.Parameters.AddWithValue("@IsDeleted", meal.IsDeleted);
        }

        private Meal GetFromReader(SqlDataReader reader)
        {
            Meal meal = new Meal();

            meal.Id = reader.GetInt32("Id");

            meal.Category = new Category()
            {
                Id = reader.GetInt32("CategoriesId"),
                Name = reader.GetString("CategoryName")
            };

            meal.Name = reader.GetString("Name");
            meal.Price = reader.GetDecimal("Price");
            meal.Quantity = reader.GetInt32("Quantity");

            if (!reader.IsDBNull("Note"))
            {
                meal.Note = reader.GetString("Note");
            }

            return meal;
        }
    }
}
