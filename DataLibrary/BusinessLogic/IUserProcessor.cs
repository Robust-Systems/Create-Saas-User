using System;

namespace DataLibrary.BusinessLogic
{
  public interface IUserProcessor : IDisposable
  {
    bool CreateUser(string emailAddress, string password);

    bool UserExists(string emailAddress);
  }
}