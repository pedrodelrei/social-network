
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Gender))]
        public int GenderId { get; set; }
        public Gender Gender { get; set;}
        [InverseProperty(nameof(FamilyPersonRelationship.PrimaryPerson))]
        public ICollection<FamilyPersonRelationship> PrimaryRelationships { get; set;}
        [InverseProperty(nameof(FamilyPersonRelationship.ForeignPerson))]
        public ICollection<FamilyPersonRelationship> ForeignRelationships { get; set;}
    }

}