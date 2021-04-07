using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Models
{
    public class Fizzbuzz
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Number { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Result { get; set; }
    }
}
