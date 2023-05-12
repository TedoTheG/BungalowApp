using BungalowApp.Data;
using BungalowApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BungalowApp.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public HomeController(ILogger<HomeController> logger,
      ApplicationDbContext context, UserManager<AppUser> userManager)
    {
      _logger = logger;
      _context = context;
      _userManager = userManager;
    }

    public IActionResult Index()
    {
      int usersCount = _userManager.Users.Count();
      int ReservationListsCount = _context.ReservationList.Count();
      int BungalowsCount = _context.Bungalow.Count();
      ViewData["UsersCount"] = usersCount;
      ViewData["ReservationsCount"] = ReservationListsCount;
      ViewData["BungalowsCount"] = BungalowsCount;
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}