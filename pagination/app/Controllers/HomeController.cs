using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Data;

namespace app.Controllers;

public class HomeController : Controller
{
    private readonly DataAccess _dataAccess;

    public HomeController(DataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public IActionResult Index(int page = 1)
    {
        const int pageSize = 15;
        var result = _dataAccess.GetDataWithPagination(page, pageSize);
        return View(result);
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
