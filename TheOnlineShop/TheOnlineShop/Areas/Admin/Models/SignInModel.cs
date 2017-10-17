using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheOnlineShop.Areas.Admin.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Nhập user name!")]
        public string UserName { set; get; }


        [Required(ErrorMessage = "Nhập password!")]
        public string Password { set; get; }


        public bool RememberMe { set; get; }
    }
}