using apbd_kl_2.DTOs;
using apbd_kl_2.Services;
using Microsoft.AspNetCore.Mvc;
namespace apbd_kl_2.Controllers;

[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacterInfo(int id)
    {
        if (!await _dbService.DoesCharacterExists(id))
        {
            return NotFound($"Character with id: {id} not found");
        }

        var characterInfo = await _dbService.GetCharacterData(id);
        
        return Ok(characterInfo.Select(e => new GetCharacerInfoDTO
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            CurrentWeight = e.CurrentWeight,
            MaxWeight = e.MaxWeight,
            BackpackItems = e.Backpacks.Select(p => new GetBackpackDTO
            {
                Amount = p.Amount,
                ItemName = p.Item.Name,
                ItemWeight = p.Item.Weight
            }).ToList(),
            Titles = e.CharacterTitles.Select(t => new GetTitleDTO
            {
                Title = t.Title.Name,
                aquiredAt = t.AcquiredAt
            }).ToList()
        }));
    }

    [HttpPost("{id}/backpacks")]
    public async Task<IActionResult> AddItems(int id, List<int> itemIds)
    {

        int itemWeights = 0;
        foreach (var item in itemIds)
        {
            if (!await _dbService.DoesItemExists(item))
            {
                return NotFound($"Item with id {item} not found");
            }

            itemWeights += await _dbService.GetItemWeight(item);
        }

        int freeSpace = await _dbService.GetCharacterFreeWeight(id);

        if (freeSpace - itemWeights < 0)
        {
            return Forbid("Dont have enough space");
        }
        
        foreach (var item in itemIds)
        {
            _dbService.AddItem(new AddItemDTO
            {
                Itemid = item,
                CharacterId = id,
                Amount = 1
                
            });
        }
        
        
        return Ok();
    }
}