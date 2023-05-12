namespace BungalowApp.Data
{
  public class Bungalow
  {
    public int Id { get; set; }   
    public string BungalowId { get; set; }
    public virtual AppUser? Assignee { get; set; }
    public int Slots { get; set; }
    public bool Smokers { get; set; }
    public bool Pets { get; set; }
    public string Location { get; set; }
    public double PricePerNight { get; set; }
    public string ReservationListId { get; set; }
    public virtual ReservationList? ReservationList { get;set; }
  }
}