
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        public int RelationshipEnumKey { get; set; }
        [InverseProperty(nameof(RelationshipGender.Relationship))]
        public ICollection<RelationshipGender> RelationshipGenders { get; set;}
    }

    public enum RelationshipEnum
    {
        None = 0,
        Parent = 1,
        Partner = 2,
        Sibling = 3,
    }
}