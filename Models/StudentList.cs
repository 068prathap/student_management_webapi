using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace JWTWebApi.Models
{
    public class StudentList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentId { get; set; }
        public int rollNo { get; set; }
        public string name { get; set; }
        public int standard { get; set; }
        public string section { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        [ForeignKey("SchoolDetails")]
        public int schoolId { get; set; }
        public virtual SchoolDetails? SchoolDetails { get; set; }
    }
}