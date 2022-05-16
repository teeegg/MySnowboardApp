using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySnowboardApp.Server.Interfaces;
using MySnowboardApp.Shared.Models;

namespace MySnowboardApp.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BoardController : ControllerBase
  {
    private readonly IBoardService _boardService;
    public BoardController(IBoardService boardService)
    {
      _boardService = boardService;
    }
    [HttpGet]
    public async Task<List<BoardInfo>> Get()
    {
      return await Task.FromResult(_boardService.GetBoardList());
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      BoardInfo board = _boardService.GetBoard(id);
      if (board != null)
      {
        return Ok(board);
      }
      return NotFound();
    }
    [HttpPost]
    public void Post(BoardInfo board)
    {
      _boardService.AddBoard(board);
    }
    [HttpPut]
    public void Put(BoardInfo board)
    {
      _boardService.UpdateBoard(board);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _boardService.DeleteBoard(id);
      return Ok();
    }
  }
}
