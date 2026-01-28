public record BorrowRequest(
    Guid BookId,
    Guid MemberId,
    DateTime BorrowDate
);