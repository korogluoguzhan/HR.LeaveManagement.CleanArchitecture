using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetAllLeaveAllocations
{
    public class GetAllLeaveAllocationQuery:IRequest<List<LeaveAllocationDto>>
    {
    }
}
