using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg;

public class User : AggregateRoot
{
    public User(string name, string family, string phoneNumber, string email, string password, Gender gender,
        IDomainUserService domainService)
    {
        Guard(phoneNumber, email, domainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Password = password;
        Gender = gender;
        Email = email;
    }

    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Gender Gender { get; private set; }
    public List<UserRole> Roles { get; }
    public List<Wallet> Wallets { get; }
    public List<UserAddress> Addresses { get; }

    public void Edit(string name, string family, string phoneNumber, string email, Gender gender,
        IDomainUserService domainService)
    {
        Guard(phoneNumber, email, domainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Gender = gender;
        Email = email;
    }

    public static User RegisterUser(string email, string phoneNumber, string password, IDomainUserService domainService)
    {
        return new User("", "", phoneNumber, email, password, Gender.Unspecified, domainService);
    }

    public void AddAddress(UserAddress address)
    {
        address.UserId = Id;
        Addresses.Add(address);
    }

    public void DeleteAddress(long addressId)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
        if (oldAddress == null) throw new NullOrEmptyDomainDataException("Address Not found");

        Addresses.Remove(oldAddress);
    }

    public void EditAddress(UserAddress address)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == address.Id);
        if (oldAddress == null) throw new NullOrEmptyDomainDataException("Address Not found");

        Addresses.Remove(oldAddress);
        Addresses.Add(address);
    }

    public void ChargeWallet(Wallet wallet)
    {
        Wallets.Add(wallet);
    }

    public void ChargeWallet(List<UserRole> role)
    {
        Roles.Clear();
        Roles.AddRange(role);
    }

    public void Guard(string phoneNumber, string email, IDomainUserService domainService)
    {
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainDataException.CheckString(email, nameof(email));
        if (phoneNumber.Length != 11)
            throw new InvalidDomainDataException("شماره موبایل نامعتبر است.");


        if (email.IsValidEmail() == false)
            throw new InvalidDomainDataException("ایمیل نامعتبر است.");
        if (phoneNumber != PhoneNumber)
            if (domainService.PhoneNumberExist(phoneNumber))
                throw new InvalidDomainDataException("شماره موبایل تکراری است.");
        if (email != Email)
            if (domainService.IsEmailExist(email))
                throw new InvalidDomainDataException("ایمیل تکراری است.");
    }
}