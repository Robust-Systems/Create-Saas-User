using DataLibrary.Common;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;

namespace DataLibrary.BusinessLogic
{
  public class UserProcessor : IUserProcessor
  {

    UserDataAccess userDataAccess;

    public UserProcessor(string connectionString)
    {
      userDataAccess = new UserDataAccess(connectionString);
    }

    public bool CreateUser(string emailAddress, string password)
    {
      string hashedPassword = EncryptionUtility.HashedText(password, out string salt);

      UserModel data = new UserModel
      {
        EmailAddress = emailAddress,
        Salt = salt,
        Password = hashedPassword
      };

      var lastId = userDataAccess.Insert(data);

      return lastId > 0;
    }

    public bool UserExists(string emailAddress)
    {
      return userDataAccess.Exists(emailAddress);
    }

    public void Dispose()
    {
      userDataAccess = null;
    }
  }
}
