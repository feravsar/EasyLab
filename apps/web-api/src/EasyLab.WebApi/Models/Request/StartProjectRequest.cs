using System;
using System.ComponentModel.DataAnnotations;

namespace EasyLab.WebApi.Models.Request
{
    public class StartProjectRequest
    {
         [Required]
        public Guid AssignmentId { get; set; }
    }
}
