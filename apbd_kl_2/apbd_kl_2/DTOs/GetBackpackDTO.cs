using apbd_kl_2.Models;

namespace apbd_kl_2.DTOs;

public class GetBackpackDTO
{
    public string ItemName { get; set; }
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}