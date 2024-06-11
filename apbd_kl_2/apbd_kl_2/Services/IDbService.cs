using apbd_kl_2.Models;

namespace apbd_kl_2.Services;

public interface IDbService
{
    Task<bool> DoesCharacterExists(int characterId);
    
    Task<bool> DoesItemExists(int itemId);

    Task<int> GetItemWeight(int itemId);

    Task<int> GetCharacterFreeWeight(int characterId);

    Task<ICollection<Characters>> GetCharacterData(int id);
}