using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HsgsGsu.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        
        public int MaId { get; set; }

        [MaxLength(25)]
        public string fNavn { get; set; }

        [MaxLength(50)]
        public string eNavn { get; set; }

        public string Deling { get; set; }

        public string Hold { get; set; }
    }
}