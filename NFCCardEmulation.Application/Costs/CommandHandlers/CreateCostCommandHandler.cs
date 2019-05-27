using AutoMapper;
using MediatR;
using NFCCardEmulation.Application.Costs.Commands;
using NFCCardEmulation.Application.Costs.Models;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Costs.CommandHandlers
{
    public class CreateCostCommandHandler : IRequestHandler<CreateCostCommand, CostDetailsModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCostCommandHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CostDetailsModel> Handle(CreateCostCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateCostCommand, Cost>(request);

            _context.Costs.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Cost, CostDetailsModel>(entity);
        }
    }
}
