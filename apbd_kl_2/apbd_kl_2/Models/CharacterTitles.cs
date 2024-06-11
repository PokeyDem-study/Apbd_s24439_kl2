using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace apbd_kl_2.Models;

[Table("CharacterTitles")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharacterTitles
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }

    public DateTime AcquiredAt { get; set; }

    [ForeignKey(nameof(CharacterId))]
    public Characters Character { get; set; } = null!;

    [ForeignKey(nameof(TitleId))]
    public Titles Title { get; set; } = null!;
}