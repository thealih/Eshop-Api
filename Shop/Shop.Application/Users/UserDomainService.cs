using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users;

public class UserDomainService:IUserDomainService
{
    public bool IsEmailExist(string email)
    {
        throw new NotImplementedException();
    }

    public bool PhoneNumberExist(string phoneNumber)
    {
        throw new NotImplementedException();
    }
}