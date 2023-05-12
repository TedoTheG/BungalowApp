using System.ComponentModel.DataAnnotations;

namespace BungalowApp.Data
{
  public class ReservationList
  {
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }
    public virtual AppUser? User { get; set; }
    public DateTime ReservationDate { get; set; }
    public virtual List<Bungalow> Bungalows { get; set; }
    public string Description { get; set; }
    public ReservationList()
    {
      Bungalows = new List<Bungalow>();
    }
  }
}