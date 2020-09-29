using DataLibrary.Models;
using System;

namespace DataLibrary.DataAccess
{
  public interface IUserDataAccess : IDisposable
  {

    Boolean Exists(string emailAddress);

    int Insert(UserModel user);

  }
}
