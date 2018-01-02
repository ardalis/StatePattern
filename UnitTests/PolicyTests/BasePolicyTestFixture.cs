using Core;
using UnitTests.Builders;

namespace UnitTests.PolicyTests
{
    public abstract class BasePolicyTestFixture
    {
        protected PolicyBuilder _policyBuilder = new PolicyBuilder();
        protected Policy _testPolicy;
        protected Policy.CancelledState _testCancelledState;
        protected Policy.ClosedState _testClosedState;
        protected Policy.OpenState _testOpenState;
        protected Policy.UnwrittenState _testUnwrittenState;
        protected Policy.VoidState _testVoidState;

        public BasePolicyTestFixture()
        {
            _testPolicy = _policyBuilder.Build();
            _testCancelledState = new Policy.CancelledState(_testPolicy);
            _testClosedState = new Policy.ClosedState(_testPolicy);
            _testOpenState = new Policy.OpenState(_testPolicy);
            _testUnwrittenState = new Policy.UnwrittenState(_testPolicy);
            _testVoidState = new Policy.VoidState(_testPolicy);
        }
    }
}
