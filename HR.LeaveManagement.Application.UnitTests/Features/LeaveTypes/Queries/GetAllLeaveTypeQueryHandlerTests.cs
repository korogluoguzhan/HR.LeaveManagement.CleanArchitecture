using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries
{
    public class GetAllLeaveTypeQueryHandlerTests
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetAllLeaveTypesQueryHandler>> _appLogger;
        public GetAllLeaveTypeQueryHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetAllLeaveTypes();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _appLogger = new Mock<IAppLogger<GetAllLeaveTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetAllLeaveTypeTests()
        {
            var handler = new GetAllLeaveTypesQueryHandler(_mapper,_mockRepo.Object,_appLogger.Object);

            var result = await handler.Handle(new GetAllLeaveTypesQuery(),CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
