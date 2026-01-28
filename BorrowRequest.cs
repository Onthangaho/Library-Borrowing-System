public record BorrowRequest(
    Guid BookId,
    int MemberId,
    DateTime BorrowDate
);