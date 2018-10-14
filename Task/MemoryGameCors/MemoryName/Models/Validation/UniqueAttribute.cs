using MemoryGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemoryName.Models.Validation
{
    public class UniqueAttribute:ValidationAttribute
    {
        public void UIHintAttribute()
        {
             ErrorMessage = "there is this user name yet";
        }
        public override bool IsValid(object value)
        {
            return !(Global.UserList.Any(user=>user.UserName==value.ToString()));
        }
    }
}