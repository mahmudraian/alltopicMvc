using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace alltopicMvc.Models
{
    public class Category
    {

        public int Id { get; set; }
        //public string Name { get; set; }

        //public string Title { get; set; }

        //public string Description { get; set; }

        //public string Image { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }


        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Category Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image File")]
        public string Image { get; set; }








    }
}


//id name	title	description	image	create_at	update_at