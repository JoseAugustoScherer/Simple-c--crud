using System.Text.Json.Serialization;

namespace firstAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
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