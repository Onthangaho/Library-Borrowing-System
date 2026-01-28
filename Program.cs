// See https://aka.ms/new-console-template for more information

Console.WriteLine("=== Library Borrowing System ===");

LibraryManager manager = new LibraryManager();

/*
 * System setup
 */
var book1 = new Book("Code is fun", "Magoro.O", false);
var book2 = new Book("C# Specification(Reference book)", "Adivhaho.M", true);

var member1 = new Member("Thangi", 223000656);
var member2 = new Member("Pfano", 223000657);

manager.AddBook(book1);
manager.AddBook(book2);
manager.AddMember(member1);
manager.AddMember(member2);

/*
 * Display books
 */
Console.WriteLine("\nAvailable Books:");
foreach (var book in manager.GetBooks())
{
    Console.WriteLine($"{book.Title} | Author: {book.Author} | ID: {book.Id}");
}

/*
 * User input
 */
Console.Write("\nEnter Book ID: ");
if (!Guid.TryParse(Console.ReadLine(), out Guid bookId))
{
    Console.WriteLine("Invalid Book ID format.");
    return;
}

Console.Write("Enter Member ID: ");
int memberId= int.Parse(Console.ReadLine()!);
/*
 * Process borrowing
 */
BorrowRequest request =
    new BorrowRequest(bookId, memberId, DateTime.Now);

try
{
    bool success = manager.TryBorrowBook(request);
    
     if (success)
    {
        Console.WriteLine("Book successfully borrowed.");

        // Find the borrowing record
        var activeBorrowing = manager.GetActiveBorrowings()
            .FirstOrDefault(b => b.Book.Id == bookId && b.Member.Id == memberId);

        if (activeBorrowing != null)
        {
            Console.WriteLine("\n--- Borrowing Details ---");
            Console.WriteLine($"Book Title : {activeBorrowing.Book.Title}");
            Console.WriteLine($"Author     : {activeBorrowing.Book.Author}");
            Console.WriteLine($"Borrower   : {activeBorrowing.Member.Name}");
            Console.WriteLine($"Member ID  : {activeBorrowing.Member.Id}");
            Console.WriteLine($"Borrow Date: {activeBorrowing.BorrowDate:d}");
            Console.WriteLine("--------------------------");
        }
    }
    else
    {
        Console.WriteLine("Book is currently unavailable.");
    }

   
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

/*
 * Display borrowing summary
 */
Console.WriteLine("\n--- Active Borrowings ---");
foreach (var borrowing in manager.GetActiveBorrowings())
{
    Console.WriteLine(
        $"{borrowing.Member.Name} borrowed '{borrowing.Book.Title}' on {borrowing.BorrowDate}"
    );
}
