using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Domain.Entities;

public class UserRole
{
    #region Constructor
    UserRole() { }
    public UserRole(Guid userId, Guid roleId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        RoleId = roleId;
        CreatedDateTime = DateTime.Now;
    }
    #endregion

#nullable disable
    public Guid Id { get; private set; }
    public DateTime CreatedDateTime { get; private set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }

    [ForeignKey("Role")]
    public Guid RoleId { get; set; }

    #region Relations
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
    #endregion
}