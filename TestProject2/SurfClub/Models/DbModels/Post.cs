using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Models.DbModels
{
    public class Post
    {
        public int Id { get; set; }

        [MaxLength(4095, ErrorMessage = "Максимальная длина — 4095 символов")]
        public string Text { get; set; }
        public Guid? Photo { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual User Author { get; set; }

    }
}
