using System;
using System.ComponentModel.DataAnnotations;

namespace EasyLab.WebApi.Models.Request{
    public class AddMemberRequest{
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public bool IsInstructor { get; set; }
    }
}