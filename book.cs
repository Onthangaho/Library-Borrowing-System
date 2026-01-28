public class Book
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; }
    public string Author { get; }
    // Indicates if the book is for reference only (cannot be borrowed)
    public bool IsReferenceOnly { get; }

    private readonly List<Borrowing> _borrowings = new();

    public Book(string title, string author, bool isReferenceOnly)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Book must have a title.");

        Title = title;
        Author = author;
        IsReferenceOnly = isReferenceOnly;
    }

    /*
     * A book is available if it has no active borrowing.
     */
    public bool IsAvailable()
    {
        return !_borrowings.Any(b => b.Status == BorrowStatus.Active);
    }

    public void AddBorrowing(Borrowing borrowing)
    {
        _borrowings.Add(borrowing);
    }

    public Borrowing? GetLastBorrowing()
    {
        return _borrowings.LastOrDefault();
    }
}
