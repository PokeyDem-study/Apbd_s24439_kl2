using apbd_kl_2.Data;
using apbd_kl_2.DTOs;
using apbd_kl_2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_kl_2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesCharacterExists(int characterId)
    {
        return await _context.Characters.AnyAsync(e => e.Id.Equals(characterId));
    }

    public async Task<bool> DoesItemExists(int itemId)
    {
        return await _context.Items.AnyAsync(e => e.Id.Equals(itemId));
    }

    public async Task<int> GetItemWeight(int itemId)
    {
        var result = await _context.Items
            .FirstOrDefaultAsync(e => e.Id.Equals(itemId));
        return result.Weight;
    }

    public async Task<int> GetCharacterFreeWeight(int characterId)
    {
        var character = await _context.Characters
            .FirstOrDefaultAsync(e => e.Id.Equals(characterId));
        
        var maxWeight = character.MaxWeight;
        var currentWeight = character.CurrentWeight;
        return maxWeight - currentWeight;
    }

    public async Task<ICollection<Characters>> GetCharacterData(int id)
    {
        return await _context.Characters
            .Include(e => e.Backpacks)
            .ThenInclude(e => e.Item)
            .Include(e => e.CharacterTitles)
            .ThenInclude(e => e.Title)
            .Where(e => e.Id.Equals(id))
            .ToListAsync();
    }

    public async Task AddItem(AddItemDTO getBackpackDto)
    {
        var backpack = new Backpacks
        {
            Amount = getBackpackDto.Amount,
            CharacterId = getBackpackDto.CharacterId,
            ItemId = getBackpackDto.Itemid
        };
        await _context.AddAsync(backpack);
        await _context.SaveChangesAsync();
    }
}