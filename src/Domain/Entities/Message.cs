namespace Chat.Domain.Entities
{
    public class Message
    {
#nullable disable
        public long Id { get; private set; }
        public string Body { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public string OwnerId { get; private set; }
#nullable enable
        public DateTime? EditedDateTime { get; set; }
        public long? ReplyId { get; set; }
        public string? RoomId { get; private set; }
        public string? GroupId { get; private set; }

#nullable disable
        #region relations
        public virtual User Owner { get; set; }
        public virtual Message ParentMessage { get; set; }
        public virtual Room Room { get; set; }
        //public virtual Group Group { get; set; }
        #endregion
    }
}