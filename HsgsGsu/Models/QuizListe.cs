using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HsgsGsu.Models
{
    [Table("QuizListe")]
    public class QuizListe
    {
        [Key]
        public int QuizId { get; set; }

        [MaxLength(33)]
        public string MobilTitel { get; set; }

        [MaxLength(255)]
        public string WebTitel { get; set; }

        [MaxLength(2048)]
        public string Beskrivelse { get; set; }

        [MaxLength(255)]
        public string Kategori { get; set; }

        [MaxLength(255)]
        public string Filnavn { get; set; }

        public int Førdag { get; set; }

        public int Lektion { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Oprettet { get; set; }

        public int AntalGange { get; set; }

    }
}