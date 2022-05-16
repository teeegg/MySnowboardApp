using MySnowboardApp.Shared.Models;

namespace MySnowboardApp.Server.Interfaces
{
  public interface IBoardService
  {
    public List<BoardInfo> GetBoardList();
    public void AddBoard(BoardInfo board);
    public void UpdateBoard(BoardInfo board);
    public BoardInfo GetBoard(int id);
    public void DeleteBoard(int id);

  }
}
