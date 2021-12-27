using Application.Interfaces;
using Application.Interfaces.Context;
using Application.Models;
using Domain.Entities;

namespace Application.Services;

public class ChatService : BaseService<Message>, IChatService
{
    #region Init
    private readonly IDbContext context;
    public ChatService(IDbContext _context)
    {
        context = _context;
    }
    #endregion
}