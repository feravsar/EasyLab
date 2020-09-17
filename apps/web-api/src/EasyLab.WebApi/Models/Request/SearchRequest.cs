using System.ComponentModel.DataAnnotations;

namespace EasyLab.WebApi.Models.Request{
    public class SearchRequest{
        [Required]
        [StringLength(50, MinimumLength=3)]
        public string SearchTerm { get; set; }
    }
}