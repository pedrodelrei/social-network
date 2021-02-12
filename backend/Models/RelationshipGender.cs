
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class RelationshipGender
    {
        public string Name { get; set; }
        public string InverseName { get; set; }
        [ForeignKey(nameof(Gender))]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey(nameof(Relationship))]
        public int RelationshipId { get; set; }
        public Relationship Relationship { get; set; }
    }
}