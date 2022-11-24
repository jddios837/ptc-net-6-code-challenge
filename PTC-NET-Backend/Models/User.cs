using System.ComponentModel.DataAnnotations;

namespace PTC_NET_Backend.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
    
    [Required]
    public bool IsDriver { get; set; }

    [Required]
    public bool Deleted { get; set; }
    
    public List<UserMood> UserMoods { get; set; }
}