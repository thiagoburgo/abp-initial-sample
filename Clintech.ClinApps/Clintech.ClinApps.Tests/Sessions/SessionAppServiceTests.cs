using System.Threading.Tasks;
using Clintech.ClinApps.Application.Contracts.Services;
using Shouldly;
using Xunit;

namespace Clintech.ClinApps.Tests.Sessions
{
    public class SessionAppServiceTests : ClinAppsTestBase
    {
        private readonly ISessionAppService _sessionAppService;

        public SessionAppServiceTests()
        {
            _sessionAppService = Resolve<ISessionAppService>();
        }

        [Fact]
        public async Task Should_Get_Current_User_When_Logged_In_As_Host()
        {
            //Arrange
            LoginAsHostAdmin();

            //Act
            var output = await _sessionAppService.GetCurrentLoginInformations();

            //Assert
            var currentUser = await GetCurrentUserAsync();
            output.User.ShouldNotBe(null);
            output.User.Name.ShouldBe(currentUser.Name);
            output.User.Surname.ShouldBe(currentUser.Surname);

            output.Tenant.ShouldBe(null);
        }

        [Fact]
        public async Task Should_Get_Current_User_And_Tenant_When_Logged_In_As_Tenant()
        {
            //Act
            var output = await _sessionAppService.GetCurrentLoginInformations();

            //Assert
            var currentUser = await GetCurrentUserAsync();
            var currentTenant = await GetCurrentTenantAsync();

            output.User.ShouldNotBe(null);
            output.User.Name.ShouldBe(currentUser.Name);

            output.Tenant.ShouldNotBe(null);
            output.Tenant.Name.ShouldBe(currentTenant.Name);
        }
    }
}
