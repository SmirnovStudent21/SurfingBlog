﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Models.DbModels
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string AboutMe { get; set; }
        public string Progress { get; set; }
        public Guid Photo { get; set; }

    }
}
