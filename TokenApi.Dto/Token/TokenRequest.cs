using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TokenApi.Dto;

public class TokenRequest
{
    [Required]
    [MaxLength(125)]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}