using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCnowe.Models
{
    public class User
    {
       
            [Key]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Surename { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public int Age { get; set; }

            public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        
    }
}

