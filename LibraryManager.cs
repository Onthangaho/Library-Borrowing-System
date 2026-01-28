public class LibraryManager
{
    private readonly List<Book> _books = new();
    private readonly List<Member> _members = new();
    private readonly List<Borrowing> _borrowings = new();

    public void AddBook(Book book) => _books.Add(book);
    public void AddMember(Member member) => _members.Add(member);

    public IEnumerable<Book> GetBooks() => _books;
    public IEnumerable<Member> GetMembers() => _members;

    /*
     * Core business logic
     */
    public bool TryBorrowBook(BorrowRequest request)
    {
        Book? book = _books.FirstOrDefault(b => b.Id == request.BookId);
        if (book == null)
            throw new InvalidOperationException("Book does not exist.");

        Member? member = _members.FirstOrDefault(m => m.Id == request.MemberId);
        if (member == null)
            throw new InvalidOperationException("Member does not exist.");

        if (book.IsReferenceOnly)
            throw new InvalidOperationException("Reference books cannot be borrowed.");

        if (!book.IsAvailable())
            return false;

        Borrowing borrowing = new Borrowing(book, member, request.BorrowDate);

        book.AddBorrowing(borrowing);
        _borrowings.Add(borrowing);

        return true;
    }

    /*
     * LINQ business questions
     */
    public IEnumerable<Borrowing> GetActiveBorrowings()
    {
        return _borrowings.Where(b => b.Status == BorrowStatus.Active);
    }

    public Dictionary<BorrowStatus, List<Borrowing>> GroupBorrowingsByStatus()
    {
        return _borrowings
            .GroupBy(b => b.Status)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
