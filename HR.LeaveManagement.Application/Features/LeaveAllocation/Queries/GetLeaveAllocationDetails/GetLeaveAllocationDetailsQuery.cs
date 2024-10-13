using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailsQuery:IRequest<LeaveAllocationDetailsDto>
    {
        public int Id { get; set; }
    }
}
