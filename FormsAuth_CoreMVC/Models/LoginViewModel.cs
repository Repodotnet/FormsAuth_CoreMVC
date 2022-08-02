using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAuth_CoreMVC.Models
{
    public class LoginViewModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }

}
