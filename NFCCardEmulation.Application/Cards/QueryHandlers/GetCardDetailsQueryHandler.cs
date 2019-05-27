using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Cards.Models;
using NFCCardEmulation.Application.Cards.Queries;
using NFCCardEmulation.Application.Exceptions;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Cards.QueryHandlers
{
    public class GetCardDetailsQueryHandler : IRequestHandler<GetCardDetailsQuery, CardDetailsModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public GetCardDetailsQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CardDetailsModel> Handle(GetCardDetailsQuery request, CancellationToken cancellationToken)
        {
            var card = _mapper.Map<CardDetailsModel>(await _context.Cards
                .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if(card == null)
                throw new NotFoundException(nameof(User), request.Id);

            return card;
        }
    }
}
