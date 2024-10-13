using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequest
{
    public class GetAllLeaveRequestQuery : IRequest<List<LeaveRequestDto>>
    {
    }
}
