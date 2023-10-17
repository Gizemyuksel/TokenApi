using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TokenApi.Base;

public abstract class BaseDto
{
    public int Id { get; set; }


    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; }

    [EmailAddress]
    [MaxLength(500)]
    public string Email { get; set; }


    [MaxLength(500)]
    [Display(Name = "Created By")]
    public string CreatedBy { get; set; }
}