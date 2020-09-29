using DataLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{

  public class UserDataAccess : IUserDataAccess
  {
    SqlHelper sqlHelper;

    public UserDataAccess(string connectionString)
    {
      sqlHelper = new SqlHelper(connectionString);
    }

    public int Insert(UserModel user)
    {
      var parameters = new List<SqlParameter>
      {
        sqlHelper.CreateParameter("@EmailAddress", 100, user.EmailAddress, DbType.String),
        sqlHelper.CreateParameter("@Salt", 100, user.Salt, DbType.String),
        sqlHelper.CreateParameter("@Password", 100, user.Password, DbType.String)
      };

      sqlHelper.Insert("UserAdd", CommandType.StoredProcedure, parameters.ToArray(), out int lastId);

      return lastId;
    }

    public bool Exists(string emailAddress)
    {
      var parameters = new List<SqlParameter>
      {
        sqlHelper.CreateParameter("@EmailAddress", 100, emailAddress, DbType.String),
      };

      var objUserExists = sqlHelper.GetScalarValue("UserExists", CommandType.StoredProcedure, parameters.ToArray());

      return (bool)objUserExists;
    }

    public void Dispose()
    {
      sqlHelper = null;
    }
  }
}
