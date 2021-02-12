
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [InverseProperty(nameof(FamilyPersonRelationship.Family))]
        public ICollection<FamilyPersonRelationship> Relationships { get; set;}
    }
}