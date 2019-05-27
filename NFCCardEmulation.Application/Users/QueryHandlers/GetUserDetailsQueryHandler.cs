using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Exceptions;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Application.Users.Models;
using NFCCardEmulation.Application.Users.Queries;
using NFCCardEmulation.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Users.QueryHandlers
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDetailsModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserDetailsModel>(await _context.Users
                .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return user;
        }
    }
}
