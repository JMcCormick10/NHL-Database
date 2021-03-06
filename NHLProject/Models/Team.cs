//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NHLProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }
    
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<int> Conference_Id { get; set; }
        public Nullable<int> Division_Id { get; set; }
    
        public virtual Conference Conference { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
