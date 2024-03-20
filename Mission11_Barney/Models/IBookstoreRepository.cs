namespace Mission11_Barney.Models;

public interface IBookstoreRepository
{ 
    IQueryable<Book> Books { get; }
}