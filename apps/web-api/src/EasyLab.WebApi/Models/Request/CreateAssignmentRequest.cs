using System;
using System.ComponentModel.DataAnnotations;

namespace EasyLab.WebApi.Models.Request
{
    public class CreateAssignmentRequest
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public DateTime Due { get; set; }

        [Required]
        public bool IsInstructor { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public int LanguageId { get; set; }
    }
}