using Core;
using System;

namespace UnitTests.Builders
{
    public class PolicyBuilder
    {
        public const string TEST_POLICY_NUMBER = "007";
        public DateTime TEST_OPEN_DATE = new DateTime(2018, 1, 1);
        public DateTime TEST_CLOSED_DATE = new DateTime(2018, 2, 1);

        private Policy _testPolicy;
        public PolicyBuilder()
        {
            _testPolicy = new Policy(TEST_POLICY_NUMBER);
        }

        public Policy Build()
        {
            return _testPolicy;
        }
    }
}
