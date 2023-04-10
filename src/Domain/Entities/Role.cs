namespace Chat.Domain.Entities;
public class Role
{
    #region Constructors
    Role() { }
    public Role(string name, string? title = null)
    {
        GenerateNewId();
        SetName(name, title);
    }
    #endregion

    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string? Title { get; private set; }

    #region Methods
    private void GenerateNewId()
    {
        Id = Guid.NewGuid();
    }

    public void SetName(string name, string? title = null)
    {
        Name = name;
        Title = title;
    }
    #endregion

    #region Relations
    public ICollection<UserRole> UserRoles { get; set; }
    #endregion
}