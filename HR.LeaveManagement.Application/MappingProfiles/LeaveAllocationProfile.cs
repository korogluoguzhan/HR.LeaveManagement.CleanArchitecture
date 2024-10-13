using AutoMapper;
using HR.LeaveManagament.Domain;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Commands.UpdateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetAllLeaveAllocations;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationDetails;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public class LeaveAllocationProfile:Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
