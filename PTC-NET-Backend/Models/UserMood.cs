using System.ComponentModel.DataAnnotations;

namespace PTC_NET_Backend.Models;

public class UserMood
{
    [Key]
    public int Id { get; set; }

    public int MoodId { get; set; }
    public Mood Mood { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int DriverId { get; set; }
    public User Driver { get; set; }
}