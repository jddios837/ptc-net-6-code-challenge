using System.ComponentModel.DataAnnotations;

namespace PTC_NET_Backend.Models;

public class Question
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Text { get; set; }
    public bool Deleted { get; set; }
}