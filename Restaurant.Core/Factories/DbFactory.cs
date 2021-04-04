using Restaurant.Core.DataAccess.SqlServer;
using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Factories
{
    public static class DbFactory
    {
        public static IUnitOfWork Create(ServerType serverType, string connectionString)
        {
            switch (serverType)
            {
                case ServerType.SqlServer:
                    {
                        return new SqlUnitOfWork(connectionString);
                    }
                default:
                    {
                        throw new NotSupportedException($"{serverType} not supported");
                    }
            }
        }
    }
}
