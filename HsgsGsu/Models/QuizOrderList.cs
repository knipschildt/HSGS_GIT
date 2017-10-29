using System.ComponentModel.DataAnnotations;

namespace HsgsGsu.Models
{
    public class QuizOrderList
    {
        [Key]
        public int OrderID { get; set; }
        public int KursusID { get; set; }
        public int MaID { get; set; }
        public bool Passed { get; set; }
        public int Score { get; set; }
        public string Navn { get; set; }
        public string DEL { get; set; }
        public string HOLD { get; set; }

        public QuizOrderList()
        {
            Passed = false;
        }
    }
}