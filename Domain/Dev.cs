using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appstore.Models
{
    public class Dev
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }


        public HashSet<App> Apps { get; set; } = new HashSet<App>();

    }
}