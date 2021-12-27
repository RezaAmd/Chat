using Application.Interfaces;
using Application.Interfaces.Context;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Services.Identity;

public class RoleService : BaseService<Role>
{
    #region Constructor
    private readonly ILookupNormalizer keyNormalizer;
    private readonly ILogger<RoleService> logger;
    private readonly IDbContext context;
    public RoleService(ILookupNormalizer _keyNormalizer,
        ILogger<RoleService> _logger,
        IDbContext _context)
    {
        keyNormalizer = _keyNormalizer;
        logger = _logger;
        context = _context;
    }

    #endregion


}