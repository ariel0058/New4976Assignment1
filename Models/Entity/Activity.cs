using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenithWebSite.Models.Entity
{
    public class Activity
    {

        
        [Key]
        public int activityId { get; set; }
        public string description { get; set; }
        [Display(Name = "Create Time")]
        public DateTime createActivity { get; set; }

        public List<Event> events { get; set; }
    }
}