using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User
{
    #region Constructors
    User() { }

    public User(string phoneNumber, RegionCode regionCode = RegionCode.Iran)
    {
        Initialize();
        SetPhoneNumber(phoneNumber, regionCode);
    }
    #endregion

    public string Id { get; private set; }
    public RegionCode RegionCode { get; private set; }
    public string PhoneNumber { get; private set; }
    public FullName? FullName { get; private set; }
    public string? Username { get; private set; }
    public PasswordHash? PasswordHash { get; private set; }
    public DateTime JoinedDate { get; private set; }

    #region Methods
    private void Initialize()
    {
        Id = Guid.NewGuid().ToString();
        JoinedDate = DateTime.Now;
    }

    public void SetPhoneNumber(string phoneNumber, RegionCode regionCode)
    {
        PhoneNumber = phoneNumber;
        RegionCode = regionCode;
    }

    public void SetUsername(string username)
    {
        Username = username;
    }

    public void SetPassword(PasswordHash password)
    {
        PasswordHash = password;
    }

    #endregion

    #region Relations
    public ICollection<Message> Messages { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    #endregion
}