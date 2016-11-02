using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MNB.Models
{
    public class MachinePart
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [DataType(DataType.Text)]
        public string Summary { get; set; }
        [Required]
        public double Weight { get; set; }

        public int Added { get; set; }
        public int Withdrawn { get; set; }

        public MachinePart()
        {
        }

        public MachinePart(string _name, double _pice, string _summary, double _weight)
        {
            Name = _name;
            Price = _pice;
            Summary = _summary;
            Weight = _weight;
        }


    }
}