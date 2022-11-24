using System.ComponentModel.DataAnnotations;

namespace PTC_NET_Backend.Models;

public class WebInfo
{
    [Key]
    [Required]
    public string CompanyId { get; set; }
    
    [Required]
    [MaxLength(60)]
    public string Name { get; set; }
}