using Web_Forum.data.DTO;
using Web_Forum.Models;

namespace Web_Forum.Helpers
{
    public static class UserHelper
    {
        public static UserViewModel Transform(UserDTO dto) => new UserViewModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            IsModerator = dto.IsModerator
        };
    }
}