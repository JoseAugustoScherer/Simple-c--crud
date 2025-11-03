using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace firstAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name cannot be empty ")]
        [MaxLength(50, ErrorMessage = "The name must have a maximum of 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The name email be empty ")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The password cannot be empty ")]
        public string Password { get; set; }

        public int? Age { get; set; }
        public string? Phone { get; set; }

        public User() { }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
        
        [JsonConstructor]
        public User(int id, string name, string email, string password, int? age, string? phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Age = age;
            Phone = phone;
        }
    }
}