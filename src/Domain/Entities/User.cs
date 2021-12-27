using Domain.Enums;

namespace Domain.Entities;

public class User
{
    #region Constructors
    User() { }
    public User(string username)
    {
        Id = Guid.NewGuid().ToString();
        Username = username;
        JoinedDate = DateTime.Now;
    }

    public User(string username, string phoneNumber, RegionCode regionCode = RegionCode.Iran)
    {
        Id = Guid.NewGuid().ToString();
        Username = username;
        PhoneNumber = phoneNumber;
        RegionCode = regionCode;
        JoinedDate = DateTime.Now;
    }
    #endregion

#nullable disable
    public string Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public RegionCode RegionCode { get; set; }
    public DateTime JoinedDate { get; set; }
#nullable enable
    public string? Name { get; set; }
    public string? Surname { get; set; }
#nullable disable

    #region Relations
    public ICollection<Message> Messages { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    #endregion
}