using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnowboardApp.Shared.Models
{
  [Table("info", Schema ="dbo")]
  public class BoardInfo
  {
    [Key]
    public int BoardId { get; set; }
    public string BoardName { get; set; } = string.Empty;
    public string? Brand { get; set; }
    public string? RiderLevel { get; set; }
    public string? BoardType { get; set; }
    public double? Flex { get; set; }
    public string? Terrain { get; set; }
    public int? YearDesign { get; set; }

  }
}
