
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pronum { get; set; }
    }

}