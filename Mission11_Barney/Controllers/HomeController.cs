using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission11_Barney.Models;

namespace Mission11_Barney.Controllers;

public class HomeController : Controller
{
    private IBookstoreRepository _repo;
    
    public HomeController(IBookstoreRepository temp)
    {
        _repo = temp;
    }
    public IActionResult Index(int page = 1)
    {
        int pageSize = 10; // Number of items per page
        // This assumes _repo.Books properly exposes an IQueryable<Book>
        var booksQuery = _repo.Books; // No need for AsQueryable() if Books is already IQueryable

        var paginatedBooks = booksQuery
            .OrderBy(b => b.BookId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var totalBooks = booksQuery.Count();
        var totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;

        return View(paginatedBooks); // Passing the paginated list of books directly as the model
    }

}