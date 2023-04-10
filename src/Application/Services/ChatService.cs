using Chat.Application.Interfaces;
using Chat.Infrastructure.Persistence.Context;

namespace Chat.Application.Services;

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