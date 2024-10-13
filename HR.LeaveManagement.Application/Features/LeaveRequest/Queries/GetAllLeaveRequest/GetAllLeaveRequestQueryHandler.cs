using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequest
{
    public class GetAllLeaveRequestQueryHandler:IRequestHandler<GetAllLeaveRequestQuery,List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetAllLeaveRequestQueryHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestDto>> Handle(GetAllLeaveRequestQuery request, CancellationToken cancellationToken)
        {

            // Check if it is logged in employee

            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestWithDetails();
            var requests = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);

            // Fill requests with employee information

            return requests;


        }

       
    }
}
