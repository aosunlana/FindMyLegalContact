namespace FindMyLegalContact.Tests.Unit
{
    public class FindMyLegalContactServiceTest_Logics
    {
        public class FindMyLegalContactServiceTest
        {
            [Fact]
            public async Task ShouldRetrieveLegalContactIfEmployeeHasDesignatedContactAsync()
            {
                // given
                Guid randomGuid = Guid.NewGuid();
                // when
            
                // then
            }

            [Fact]
            public async Task ShouldRetrieveLegalContactIfEmployeesManagerHasDesignatedContactAsync()
            {
                // given
            
                // when
            
                // then
            }

            [Fact]
            public async Task ShouldRetrieveLegalContactIfEmployeesManagersManagerHasDesignatedContact()
            {
                // given
            
                // when
            
                // then
            }
        }
    }
}