using System.ComponentModel.DataAnnotations;
namespace Web_Forum.Models
    
{
    public class ThreadViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
    }
}