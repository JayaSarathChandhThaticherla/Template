using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Needed for [Table] attribute

namespace Server.Models
{
    // This attribute explicitly sets the table name in the database to "UserDetails"
    [Table("UserTable")]
    public class UserTable
    {
        [Key] // Designates Id as the primary key
        public int Id { get; set; }

        [Required] // Ensures this field is not null/empty in the database
        [StringLength(50)] // Sets max length for the database column
        public string FirstName { get; set; } = string.Empty; // Re-added initializer

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty; // Re-added initializer

        [Required]
        [EmailAddress] // Provides email format validation
        [StringLength(100)]
        public string Email { get; set; } = string.Empty; // Re-added initializer

        // This will store the HASHED password.
        // It's crucial for security that this stores a hashed value, not plain text.
        [Required] // Ensures this field is not null/empty in the database
        [StringLength(255)] // Hashed passwords are typically longer, ensure enough space
        public string Password { get; set; } = string.Empty; // Re-added initializer
    }
}
