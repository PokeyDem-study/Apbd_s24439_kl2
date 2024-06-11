using apbd_kl_2.Models;

namespace apbd_kl_2.DTOs;

public class GetCharacerInfoDTO
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public int CurrentWeight { get; set; }

    public int MaxWeight { get; set; }

    public ICollection<GetBackpackDTO> BackpackItems { get; set; } = null!;

    public List<GetTitleDTO> Titles { get; set; } = null!;
}