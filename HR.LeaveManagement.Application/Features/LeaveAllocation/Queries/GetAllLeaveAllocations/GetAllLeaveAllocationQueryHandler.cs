using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetAllLeaveAllocations
{
    public class GetAllLeaveAllocationQueryHandler:IRequestHandler<GetAllLeaveAllocationQuery,List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetAllLeaveAllocationQueryHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper)
        {
          _leaveAllocationRepository = leaveAllocationRepository;
          _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetAllLeaveAllocationQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails();
            var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocation);
            return allocations;
        }
    }
}
