using System.ComponentModel.DataAnnotations;

namespace PTC_NET_Backend.Models;

public class Mood
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(10)]
    public string? SmileCode { get; set; }
    
    [MaxLength(200)]
    public string? Description { get; set; }
    
    public bool Deleted { get; set; } = false;
}