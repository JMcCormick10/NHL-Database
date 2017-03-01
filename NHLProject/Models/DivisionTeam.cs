using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHLProject.Models
{
    public class DivisionTeam
    {
        public Division divisions { get; set; }
        public List<Team> teams { get; set; }
    }
}