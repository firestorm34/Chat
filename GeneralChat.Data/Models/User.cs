using System.ComponentModel.DataAnnotations;

namespace GeneralChat.Data.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Nickname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


    }
}
