using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Cards.Models;
using NFCCardEmulation.Application.Cards.Queries;
using NFCCardEmulation.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Cards.QueryHandlers
{
    public class GetCardsQueryHandler : IRequestHandler<GetCardsQuery, CardListViewModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public GetCardsQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CardListViewModel> Handle(GetCardsQuery request, CancellationToken cancellationToken)
        {
            var cards = await _context.Cards
                .Where(x => x.UserId == request.UserId)
                .ToListAsync();

            var model = new CardListViewModel
            {
                Cards = _mapper.Map<IEnumerable<CardDetailsModel>>(cards)
            };

            return model;
        }
    }
}
