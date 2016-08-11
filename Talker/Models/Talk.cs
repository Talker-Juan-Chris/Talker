using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;


namespace Talker.Models
{
    public class Talk
    {
        public int TalkID { get; set; }
        [MaxLength(150)]
        public string TalkContent { get; set; }
        [DataType (DataType.DateTime)]
        public string timestamp { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    } 
}