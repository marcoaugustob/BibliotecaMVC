using Biblioteca.Models;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext db = new ApplicationDbContext();
    }
}