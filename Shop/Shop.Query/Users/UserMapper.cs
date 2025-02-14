using Shop.Domain.UserAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users;

public static class UserMapper
{
    public static UserDto Map(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            Name = user.Name,
            CreationDate = user.CreationDate,
            AvatarName = user.AvatarName,
            Email = user.Email,
            Family = user.Family,
            Gender = user.Gender,
            PhoneNumber = user.PhoneNumber,
            Password = user.Password,
            Roles = user.Roles.Select(s=>new UserRoleDto()
            {
                RoleId = s.RoleId,
                RoleTilte = ""
            }).ToList()
        };
    }

    public static async Task<UserDto> SetUserRoleTitle(this UserDto userDto , ShopContext _context)
    {
        var roleIds = userDto.Roles.Select(r => r.RoleId);
        var result = _context.Roles.Where(r => roleIds.Contains(r.Id)).ToList();
        var roles = new List<UserRoleDto>();
        foreach (var role in result)
        {
            roles.Add(new UserRoleDto()
            {
                RoleId = role.Id,
                RoleTilte = role.Title
            });
        }

        userDto.Roles = roles;
        return userDto;
    }

    public static UserFilterData MapFilterData(this User user)
    {
        return new UserFilterData()
        {
            Id = user.Id,
            Name = user.Name,
            CreationDate = user.CreationDate,
            AvatarName = user.AvatarName,
            Email = user.Email,
            Family = user.Family,
            Gender = user.Gender,
            PhoneNumber = user.PhoneNumber
        };
    }

}