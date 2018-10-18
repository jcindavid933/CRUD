using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class User
    {
        [Key]
        public int id {get;set;}
        [Required]
        [MinLength(3)]
        public string name{get;set;}
        [Required]
        [MinLength(3)]
        public string dish{get;set;}
        [Required]
        [Range(1,100000)]
        public int calories{get;set;}
        [Required]
        public int tastiness{get;set;}
        [Required]
        [MinLength (5)]
        public string description{get;set;}
    }
}