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
            
            var expectedLegalContact = new LegalContact
            {
                EmployeeId = employeeId, LegalContactId = Guid.NewGuid()
            };
            
            this.legalContactBrokerMock.Setup(broker =>
                    broker.GetDesignatedLegalContact(employeeId))
                .ReturnsAsync(expectedLegalContact);
            
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
            LegalContact nullEmployeeLegalContact = null;
            Employee manager = new Employee { Id = managerId };
            Employee employee = new Employee { Id = employeeId, Manager = manager };

            var expectedLegalContact =
                new LegalContact
                {
                    EmployeeId = managerId, LegalContactId = Guid.NewGuid()
                };

            this.legalContactBrokerMock.Setup(broker =>
                    broker.GetDesignatedLegalContact(managerId))
                .ReturnsAsync(expectedLegalContact);
    
            this.legalContactBrokerMock.Setup(broker =>
                    broker.GetDesignatedLegalContact(employeeId))
                .ReturnsAsync(nullEmployeeLegalContact);
    
            // when
            ValueTask<LegalContact> actualLegalContact =
                this.legalContactService.RetrieveLegalContact(employee);

            // then
            actualLegalContact.Should().BeEquivalentTo(expectedLegalContact);
    
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
            // given
            Guid employeeId = Guid.NewGuid();
            Guid managerId = Guid.NewGuid();
            Guid managersManagerId = Guid.NewGuid();
            LegalContact nullEmployeeLegalContact = null;
            LegalContact nullEmployeeManagerLegalContact = null;
            
            Employee managersManager = new Employee { Id = managersManagerId };
            Employee manager = new Employee { Id = managerId, Manager = managersManager };
            Employee employee = new Employee { Id = employeeId, Manager = manager };
            
            var expectedLegalContact =
                new LegalContact
                {
                    EmployeeId = managersManagerId, LegalContactId = Guid.NewGuid()
                };

            this.legalContactBrokerMock.Setup(broker =>
                    broker.GetDesignatedLegalContact(managersManagerId))
                .ReturnsAsync(expectedLegalContact);
    
            this.legalContactBrokerMock.Setup(broker =>
                    broker.GetDesignatedLegalContact(managerId))
                .ReturnsAsync(nullEmployeeManagerLegalContact);

            this.legalContactBrokerMock.Setup(broker =>
                    broker.GetDesignatedLegalContact(employeeId))
                .ReturnsAsync(nullEmployeeLegalContact);
            
            // when
            ValueTask<LegalContact> actualLegalContact =
                this.legalContactService.RetrieveLegalContact(employee);
            
            // then
            actualLegalContact.Should().BeEquivalentTo(expectedLegalContact);
    
            this.legalContactBrokerMock.Verify(broker =>
                    broker.GetDesignatedLegalContact(employeeId),
                Times.Once);
    
            this.legalContactBrokerMock.Verify(broker =>
                    broker.GetDesignatedLegalContact(managerId),
                Times.Once);
    
            this.legalContactBrokerMock.Verify(broker =>
                    broker.GetDesignatedLegalContact(managersManagerId),
                Times.Once);
    
            this.legalContactBrokerMock.VerifyNoOtherCalls();
           
        }
    }
}