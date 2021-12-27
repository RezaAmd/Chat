using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class Group
{
    #region Constructors

    #endregion
#nullable disable
    public string Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDateTime { get; set; }
    [ForeignKey("Owner")]
    public string OwnerId { get; set; }
#nullable enable
    public string? Token { get; set; }
    public string? Avatar { get; set; }

#nullable disable
    #region Relations
    public virtual User Owner { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<GroupUser> Users { get; set; }
    #endregion
}