using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanHangMVC.Models;
using X.PagedList;

namespace WebBanHangMVC.Controllers
{
	public class HomeController : Controller
	{
        MasterContext db = new MasterContext();
        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(int? page)
		{
			int pageSize = 8;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var listProduct = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
			PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(listProduct, pageNumber, pageSize);
			return View(list);
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
