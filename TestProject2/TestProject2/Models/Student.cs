﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestProject2.Models
{
    public class Student
    {  
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; } // 1 - female, 2 - male, 0 - non-binary
    }
}
