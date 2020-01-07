using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Models.ViewDataModel
{
    public class MovieViewDataModel
    {
        public List<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}