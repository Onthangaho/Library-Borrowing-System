public class Member
{
    public int Id { get; } 
    public string Name { get; }

    public Member(string name, int id)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Member must have a name.");

        Name = name;
        Id = id;
    }
}       
    
