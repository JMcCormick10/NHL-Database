using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHLProject.Models
{
    public class ConferenceDivision
    {
        public List<Division> divisions { get; set; }
        public Conference conferences { get; set; }
    }
}