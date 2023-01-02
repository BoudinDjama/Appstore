using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appstore.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Author { get; set; }

        public int Rating { get; set; }
        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public App App { get; set; }

    }
}