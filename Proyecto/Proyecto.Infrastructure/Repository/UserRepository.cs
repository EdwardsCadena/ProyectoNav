using Microsoft.EntityFrameworkCore;
using Proyecto.Core.Entities;
using Proyecto.Core.Interfaces;
using Proyecto.Infrastructure.Data;
using Proyecto.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PruebaContext _context;
        protected readonly DbSet<User> _entities;
        private readonly IPasswordService _passwordService;

        public UserRepository(PruebaContext context, IPasswordService passwordService)
        {
            _context = context;
            _entities = context.Set<User>();
            _passwordService = passwordService;
        }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User1 == login.User);
        }
        public async Task RegisterUser(User user)
        {
            DateTime currentDate = DateTime.Now;
            User registro = new User
            {
                User1 = user.User1,
                Password = user.Password,
                DateCreation = currentDate,
            };
            _context.Users.Add(registro);
            await _context.SaveChangesAsync();
        }
    }
}
