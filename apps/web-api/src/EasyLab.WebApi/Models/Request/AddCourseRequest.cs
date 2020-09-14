using System.ComponentModel.DataAnnotations;

namespace EasyLab.WebApi.Models.Request
{
    public class AddCourseRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set;}
    }
}