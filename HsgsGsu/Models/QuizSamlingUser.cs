using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HsgsGsu.Models
{
    public class QuizSamlingUser
    {
        public User User { get; set; }
        public QuizListe Qliste { get; set; }
        public List<QuizOrderList> QOListe { get; set; }
        
    }
}