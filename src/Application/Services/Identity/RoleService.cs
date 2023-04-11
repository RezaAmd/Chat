using Chat.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Chat.Application.Services.Identity;

public class RoleService
{
    #region Constructor
    private readonly ILookupNormalizer keyNormalizer;
    private readonly ILogger<RoleService> logger;
    private readonly Infrastructure.Persistence.Context.AppDbContext context;
    public RoleService(ILookupNormalizer _keyNormalizer,
        ILogger<RoleService> _logger,
        Infrastructure.Persistence.Context.AppDbContext _context)
    {
        keyNormalizer = _keyNormalizer;
        logger = _logger;
        context = _context;
    }
    #endregion


}