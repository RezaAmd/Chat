using Application.Interfaces;
using Infrastructure.Persistence.Context;

namespace Application.Services;

public class ChatService : IChatService
{
    #region Init
    private readonly IdentityDbContext context;
    public ChatService(IdentityDbContext _context)
    {
        context = _context;
    }
    #endregion
}