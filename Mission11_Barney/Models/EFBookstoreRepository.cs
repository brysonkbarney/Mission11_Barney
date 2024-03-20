namespace Mission11_Barney.Models;

public class EFBookstoreRepository : IBookstoreRepository
{
    private BookstoreContext _context;

    public EFBookstoreRepository(BookstoreContext temp)
    {
        _context = temp;
    }

    // Keep Books as IQueryable to allow for further query composition like pagination
    public IQueryable<Book> Books => _context.Books;
}