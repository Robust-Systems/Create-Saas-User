using DataLibrary.BusinessLogic;
using Microsoft.Extensions.Configuration;
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

    public bool CreateUserAccount(UserModel model)
    {
      return userProcessor.CreateUser(model.EmailAddress, model.Password);
    }

    public bool UserAlreadyExists(string emailAddress)
    {
      return userProcessor.UserExists(emailAddress);
    }
  }
}
