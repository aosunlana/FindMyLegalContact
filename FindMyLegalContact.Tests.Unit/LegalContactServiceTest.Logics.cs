using Castle.Components.DictionaryAdapter;
using FindMyLegalContact.Models;
using FluentAssertions;
using Moq;

namespace FindMyLegalContact.Tests.Unit
{
    public partial class LegalContactServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveLegalContactIfEmployeeHasDesignatedContactAsync()
        {
            // given
            Guid randomGuid = Guid.NewGuid();
            Guid employeeId = randomGuid;
            Employee randomEmployee = GetRandomEmployeeWithId(employeeId);
            LegalContact randomLegalContact = GetRandomLegalContact();
            LegalContact expectedLegalContact = randomLegalContact;

            this.legalContactBrokerMock.Setup(broker =>
                    broker.GetDesignatedLegalContact(employeeId))
                .Returns(expectedLegalContact);
            
            // when
            ValueTask<LegalContact> actualLegalContact =
                this.legalContactService.RetrieveLegalContact(randomEmployee);

            // then
            actualLegalContact.Should().BeEquivalentTo(expectedLegalContact);
            
            this.legalContactBrokerMock.Verify(broker =>
                    broker.GetDesignatedLegalContact(employeeId),
                Times.Once);
            
            this.legalContactBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldRetrieveLegalContactIfEmployeesManagerHasDesignatedContactAsync()
        {
            // given
            Guid employeeId = Guid.NewGuid();
            Guid managerId = Guid.NewGuid();
            Employee employee = GetRandomEmployeeWithId(employeeId);
            Employee manager = GetRandomEmployeeWithId(managerId);
            LegalContact nuillLegalContact = null;
            LegalContact managerLegalContact = GetRandomLegalContact();

            employee.Manager.Id = managerId;

            this.legalContactBrokerMock.Setup(broker =>
                    broker.GetDesignatedLegalContact(employeeId))
                .Returns(nuillLegalContact);
    
            this.legalContactBrokerMock.Setup(broker =>
                    broker.GetDesignatedLegalContact(managerId))
                .Returns(managerLegalContact);

            // when
            LegalContact actualLegalContact =
                await this.legalContactService.RetrieveLegalContact(employee);

            // then
            actualLegalContact.Should().BeEquivalentTo(managerLegalContact);
    
            this.legalContactBrokerMock.Verify(broker =>
                    broker.GetDesignatedLegalContact(employeeId),
                Times.Once);
    
            this.legalContactBrokerMock.Verify(broker =>
                    broker.GetDesignatedLegalContact(managerId),
                Times.Once);

            this.legalContactBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldRetrieveLegalContactIfEmployeesManagersManagerHasDesignatedContact()
        {
           
        }
    }
}