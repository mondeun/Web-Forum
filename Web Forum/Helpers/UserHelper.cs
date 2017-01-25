using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Forum.data.DTO;
using Web_Forum.Models;

namespace Web_Forum.Helpers
{
    public class UserHelper
    {
        public static UserViewModel GetUserViewModelFromDto(UserDTO dto) => new UserViewModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            IsModerator = dto.IsModerator
        };
    }
}