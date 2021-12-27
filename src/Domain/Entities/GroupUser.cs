using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GroupUser
    {
        #region Constructors

        #endregion
#nullable disable
        public DateTime JoinedDateTime { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Group")]
        public string GroupId { get; set; }

        #region Relations
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
        #endregion
    }
}
