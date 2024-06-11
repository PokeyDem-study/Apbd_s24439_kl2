using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace apbd_kl_2.Models;

[Table("Titles")]
public class Titles
{
    [Key] 
    public int Id { get; set; }
    
    [MaxLength(100)] 
    public string Name { get; set; }
    
    public ICollection<CharacterTitles> CharacterTitles { get; set; } = new HashSet<CharacterTitles>();
}