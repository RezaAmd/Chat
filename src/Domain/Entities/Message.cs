namespace Domain.Entities
{
    public class Message
    {
#nullable disable
        public long Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string OwnerId { get; set; }
#nullable enable
        public DateTime? EditedDateTime { get; set; }
        public long? ReplyId { get; set; }
        public string? RoomId { get; set; }
        public string? GroupId { get; set; }

#nullable disable
        #region relations
        public virtual User Owner { get; set; }
        public virtual Message ParentMessage { get; set; }
        public virtual Room Room { get; set; }
        //public virtual Group Group { get; set; }
        #endregion
    }
}