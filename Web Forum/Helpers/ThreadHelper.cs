using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Forum.data.DTO;
using Web_Forum.Models;

namespace Web_Forum.Helpers
{
    public static class ThreadHelper
    {
        public static ThreadDTO Transform(this ThreadViewModel thread)
        {
            var dto = new ThreadDTO
            {
                Title: thread.Title,
                Name: thread.Name,
                Text: thread.Text
            };
        return dto;


        }
}
