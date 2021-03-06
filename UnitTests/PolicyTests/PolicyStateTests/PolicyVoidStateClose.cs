﻿using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyVoidStateClose : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testVoidState.Close(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
