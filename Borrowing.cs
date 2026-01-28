public class Borrowing
{
    public Guid Id { get; } = Guid.NewGuid();
    public Book Book { get; }
    public Member Member { get; }
    public DateTime BorrowDate { get; }
    public BorrowStatus Status { get; private set; }

    public Borrowing(Book book, Member member, DateTime borrowDate)
    {
        Book = book;
        Member = member;
        BorrowDate = borrowDate;
        Status = BorrowStatus.Active;
    }

    public void ReturnBook()
    {
        if (Status != BorrowStatus.Active)
            throw new InvalidOperationException("Only active borrowings can be returned.");

        Status = BorrowStatus.Returned;
    }
}
