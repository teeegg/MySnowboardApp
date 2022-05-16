using MySnowboardApp.Server.Interfaces;
using MySnowboardApp.Server.Model;
using MySnowboardApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace MySnowboardApp.Server.Services
{
  public class BoardService : IBoardService
  {
    readonly SnowboardContext _dbContext = new();
    public BoardService(SnowboardContext dbContext)
    {
      _dbContext = dbContext;
    }

    public List<BoardInfo> GetBoardList()
    {
      try
      {
        return _dbContext.Board.ToList();
      }
      catch
      {
        throw;
      }
    }

    public void AddBoard(BoardInfo board)
    {
      try
      {
        _dbContext.Board.Add(board);
        _dbContext.SaveChanges();
      }
      catch
      {
        throw;
      }
    }

    public void UpdateBoard(BoardInfo board)
    {
      try
      {
        _dbContext.Entry(board).State = EntityState.Modified;
        _dbContext.SaveChanges();
      }
      catch
      {
        throw;
      }
    }

    public BoardInfo GetBoard(int id)
    {
      try
      {
        BoardInfo? board = _dbContext.Board.Find(id);
        if (board != null)
        {
          return board;
        }
        else
        {
          throw new ArgumentException();
        }
      }
      catch
      {
        throw;
      }
    }

    public void DeleteBoard(int id)
    {
      try
      {
        BoardInfo? board = _dbContext.Board.Find(id);
        if (board != null)
        {
          _dbContext.Board.Remove(board);
          _dbContext.SaveChanges();
        }
        else
        {
          throw new ArgumentException();
        }
      }
      catch
      {
        throw;
      }
    }
  }
}
