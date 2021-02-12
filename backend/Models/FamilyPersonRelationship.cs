
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class FamilyPersonRelationship
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Family))]
        public int FamilyId { get; set; }
        public Family Family { get; set; }
        [ForeignKey(nameof(Relationship))]
        public int RelationshipId { get; set; }
        public Relationship Relationship { get; set; }
        public int PrimaryPersonId { get; set; }
        public Person PrimaryPerson { get; set; }
        public int ForeignPersonId { get; set; }
        public Person ForeignPerson { get; set; }
    }

}