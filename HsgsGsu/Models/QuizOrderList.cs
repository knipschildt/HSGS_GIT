using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HsgsGsu.Models
{
    public class QuizOrderList
    {
        [Key]
        public int OrderID { get; set; }
        public int KursusID { get; set; }
        public int MaID { get; set; }
        public bool Passed { get; set; }


        public QuizOrderList()
        {
            Passed = false;
        }
    }
}