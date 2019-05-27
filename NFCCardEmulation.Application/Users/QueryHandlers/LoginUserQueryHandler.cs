using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Exceptions;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Application.Users.Models;
using NFCCardEmulation.Application.Users.Queries;
using NFCCardEmulation.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Users.QueryHandlers
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public LoginUserQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LoginUserModel> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return null;

            var user = await _context.Users
                 .SingleOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request);
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            return _mapper.Map<LoginUserModel>(user);
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
