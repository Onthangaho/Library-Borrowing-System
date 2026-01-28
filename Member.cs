public class Member
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }

    public Member(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Member must have a name.");

        Name = name;
    }
}