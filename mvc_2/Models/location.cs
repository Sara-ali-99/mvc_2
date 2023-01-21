﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_2.Models
{
    public class location
    {
      
        public string? Location { get; set; }

        [ForeignKey("Department")]
        public int DeptNumber { get; set; }
        public Department? Department { get; set; }
    }
}
