namespace Chat.Domain.Entities;
public class Role
{
    #region Constructors
    Role() { }
    public Role(string name)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
    }
    #endregion

    public string Id { get; set; }
    public string Name { get; set; }

    #region Relations
    public ICollection<UserRole> UserRoles { get; set; }
    #endregion
}