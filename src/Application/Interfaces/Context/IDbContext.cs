using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Context
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<GroupUser> GroupUsers { get; set; }
        //DbSet<Room> Rooms { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        TEntity Set<TEntity>();
    }
}