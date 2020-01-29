using MVC_LoginAndRegister.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_LoginAndRegister.Models
{
    public class ExternalLoginConfirmationView
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListView
    {
        public string ReturnUrl { get; set; }
    }
    [Table("TB_M_Users")]
    public class User : BaseModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }


        public User() { }
        public User(int id,string username,string password)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
        }
    }
}