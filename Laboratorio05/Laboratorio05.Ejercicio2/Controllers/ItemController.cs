using Laboratorio05.Ejercicio2.Contracts;
using Laboratorio05.Ejercicio2.Models;
using Laboratorio05.Ejercicio2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Laboratorio05.Ejercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository) 
        { 
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public ActionResult<List<Item>> GetItems()
        {
            return _itemRepository.GetItems();
        }

        [HttpPost]
        public ActionResult CreateItem(Item item)
        {
            try
            {
                _itemRepository.CreateItem(item);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            try { 
                var item = _itemRepository.GetItemById(id);
                return Ok(item);
            }
            catch (System.Exception e) { 
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateItem(Item item) 
        {
            try
            {
                _itemRepository.UpdateItem(item);
                return Ok();
            }
            catch (System.Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("add/{id}/{amount}")]
        public ActionResult AddStock(int id, int amount) 
        { 
            try
            {
                _itemRepository.AddStock(id, amount);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("remove/{id}/{amount}")]
        public ActionResult RemoveStock(int id, int amount)
        {
            try
            {
                _itemRepository.RemoveStock(id, amount);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
