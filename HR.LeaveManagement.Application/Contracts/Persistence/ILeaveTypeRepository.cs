﻿using HR.LeaveManagament.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }

}
