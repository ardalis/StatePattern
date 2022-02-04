using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyOpenStateUpdate : BasePolicyTestFixture
    {
        [Fact]
        public void DoesNotThrow()
        {
            _testOpenState.Update();
        }
    }
}
