using AutoMapper;
using MediatR;
using NFCCardEmulation.Application.Cards.Commands;
using NFCCardEmulation.Application.Cards.Models;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Cards.CommandHandlers
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, CardDetailsModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCardCommandHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CardDetailsModel> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = _mapper.Map<CreateCardCommand, Card>(request);

            _context.Cards.Add(card);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Card, CardDetailsModel>(card);
        }
    }
}
