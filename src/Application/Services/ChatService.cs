using Chat.Application.Interfaces;

namespace Chat.Application.Services;

public class ChatService : IChatService
{
    #region Init
    private readonly AppDbContext context;
    public ChatService(AppDbContext _context)
    {
        context = _context;
    }
    #endregion
}