using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HsgsGsu.Models
{
    [Table("SjantPic")]
    public class Sjantpic
    {
        [Key]
        public int PicId { get; set; }

        [MaxLength(255)]
        public string Overskrift { get; set; }

        [MaxLength(1024)]
        public string FileName { get; set; }

        [MaxLength(2048)]
        public string Beskrivelse { get; set; }

        [MaxLength(255)]
        public string Kategori { get; set; }

        public int Likes { get; set; }

        public int CommentId { get; set; }

        public DateTime Oprettet { get; set; }

        public int Deling { get; set; }

        [MaxLength(128)]
        [Required]
        public string Ejer { get; set; }

    }
}