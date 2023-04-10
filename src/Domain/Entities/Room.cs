namespace Chat.Domain.Entities;

public class Room
{
    #region Constructors
    Room() { }
    public Room(string userId)
    {

    }
    #endregion
    public string Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string UserId { get; set; }
    #region Relations

    #endregion
}