using System.Data;

namespace RentCar.Application.Abstraction.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}