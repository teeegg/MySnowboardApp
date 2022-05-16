using MySnowboardApp.Shared.Models;
using System.Net.Http.Json;

namespace MySnowboardApp.Client.Pages
{
  public partial class Information
  {

    private List<string> editEvents = new();
    private bool dense = false;
    private bool hover = true;
    private bool ronly = false;
    private bool canCancelEdit = false;
    private bool blockSwitch = false;
    private string searchString = "";
    private BoardInfo selectedItem1 = null;
    private BoardInfo elementBeforeEdit;
    private HashSet<BoardInfo> selectedItems1 = new HashSet<BoardInfo>();

    private IEnumerable<BoardInfo> boards = new List<BoardInfo>();

    protected override async Task OnInitializedAsync()
    {
      boards = await Http.GetFromJsonAsync<List<BoardInfo>>("api/Board");
    }

    private void ClearEventLog()
    {
      editEvents.Clear();
    }

    private void AddEditionEvent(string message)
    {
      editEvents.Add(message);
      StateHasChanged();
    }

    private void BackupItem(object element)
    {
      elementBeforeEdit = new()
      {
        BoardName = ((BoardInfo)element).BoardName,
        Brand = ((BoardInfo)element).Brand,
        RiderLevel = ((BoardInfo)element).RiderLevel,
        BoardType = ((BoardInfo)element).BoardType,
        Flex = ((BoardInfo)element).Flex,
        Terrain = ((BoardInfo)element).Terrain,
        YearDesign = ((BoardInfo)element).YearDesign
      };
      AddEditionEvent($"RowEditPreview event: made a backup of Element {((BoardInfo)element).BoardName}");
    }

    private void ItemHasBeenCommitted(object element)
    {
      AddEditionEvent($"RowEditCommit event: Changes to Element {((BoardInfo)element).BoardName} committed");
    }

    private void ResetItemToOriginalValues(object element)
    {
      ((BoardInfo)element).BoardName = elementBeforeEdit.BoardName;
      ((BoardInfo)element).Brand = elementBeforeEdit.Brand;
      ((BoardInfo)element).RiderLevel = elementBeforeEdit.RiderLevel;
      ((BoardInfo)element).BoardType = elementBeforeEdit.BoardType;
      ((BoardInfo)element).Flex = elementBeforeEdit.Flex;
      ((BoardInfo)element).Terrain = elementBeforeEdit.Terrain;
      ((BoardInfo)element).YearDesign = elementBeforeEdit.YearDesign;
      AddEditionEvent($"RowEditCancel event: Editing of Element {((BoardInfo)element).BoardName} cancelled");
    }

    private bool FilterFunc(BoardInfo element)
    {
      if (string.IsNullOrWhiteSpace(searchString))
        return true;
      if (element.BoardName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
        return true;
      if (element.Brand.Contains(searchString, StringComparison.OrdinalIgnoreCase))
        return true;
      //if ($"{element.Number} {element.Position} {element.Molar}".Contains(searchString))
      //    return true;
      return false;
    }

  }
}
