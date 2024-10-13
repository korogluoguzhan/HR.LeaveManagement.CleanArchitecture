using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<DeleteLeaveTypeCommandHandler> _logger;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,IAppLogger<DeleteLeaveTypeCommandHandler> logger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveTypeToDelete is null)
            {
                _logger.LogWarning("Get Leave Type Details is not found for {0} - {1}", nameof(LeaveType), request.Id);
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
            return Unit.Value;
        }
    }
}
