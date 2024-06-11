using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace apbd_kl_2.Models;

[Table("Characters")]
public class Characters
{
    [Key] 
    public int Id { get; set; }
    
    [MaxLength(50)] 
    public string FirstName { get; set; }
    
    [MaxLength(120)] 
    public string LastName { get; set; }
    
    public int CurrentWeight { get; set; }

    public int MaxWeight { get; set; }
    
    public ICollection<CharacterTitles> CharacterTitles { get; set; } = new HashSet<CharacterTitles>();
    
    public ICollection<Backpacks> Backpacks { get; set; } = new HashSet<Backpacks>();
}