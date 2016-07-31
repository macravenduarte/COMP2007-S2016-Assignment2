using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COMP2007_S2016_Assignment2.Models
{
    public class MenuItems
    {
        public virtual int ID { get; set; }
        
        public virtual string ItemName { get; set; }

        [DataType(DataType.Currency)]
        public virtual decimal ItemPrice { get; set; }

        [Display(Name = "Short Description")]
        public virtual string ShortDesc { get; set; }

        [Display(Name = "Long Description")]
        public virtual string LongDesc { get; set; }

        [Display(Name = "Thumbnail")]
        public virtual string ThumbnailURL { get; set; }

        [Display(Name = "Fullsize")]
        public virtual string FullsizeURL { get; set; }
    }
}