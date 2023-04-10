using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Domain.Entities;

public class UserRole
{
    #region Constructor
    UserRole() { }
    public UserRole(string userId, string roleId)
    {
        UserId = userId;
        RoleId = roleId;
        CreatedDateTime = DateTime.Now;
    }
    #endregion

#nullable disable
    public DateTime CreatedDateTime { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }

    [ForeignKey("Role")]
    public string RoleId { get; set; }

    #region Relations
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
    #endregion
}