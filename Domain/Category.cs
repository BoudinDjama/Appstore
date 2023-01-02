using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Appstore.Models
{
    public class Category
    {
        public Category()
        {
           
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public HashSet<App> Apps { get; set; } = new HashSet<App>();

        public string getName()
        {
            return this.Name; 
        }

        public object getCategoryName()
        {
            throw new NotImplementedException();
        }
    }
}