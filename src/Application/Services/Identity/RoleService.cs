using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Services.Identity;

public class RoleService
{
    #region Constructor
    private readonly ILookupNormalizer keyNormalizer;
    private readonly ILogger<RoleService> logger;
    private readonly IdentityDbContext context;
    public RoleService(ILookupNormalizer _keyNormalizer,
        ILogger<RoleService> _logger,
        IdentityDbContext _context)
    {
        keyNormalizer = _keyNormalizer;
        logger = _logger;
        context = _context;
    }
    #endregion


}