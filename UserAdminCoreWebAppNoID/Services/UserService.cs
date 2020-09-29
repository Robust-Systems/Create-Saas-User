using DataLibrary.BusinessLogic;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAdminCoreWebAppNoID.Models;

namespace UserAdminCoreWebAppNoID.Services
{
  public class UserService
  {
    readonly UserProcessor userProcessor;

    public UserService(IConfiguration configuration)
    {
      string connectionString = configuration["ConnectionStrings:UserDB"];
      userProcessor = new UserProcessor(connectionString);
    }

    public void CreateUserAccount(UserModel model)
    {
      userProcessor.CreateUser(model.EmailAddress, model.Password);
    }
  }
}
