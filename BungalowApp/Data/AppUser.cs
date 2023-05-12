﻿using Microsoft.AspNetCore.Identity;

namespace BungalowApp.Data
{
  public class AppUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public virtual List<ReservationList> Reservations{ get; set; }
  }
}
