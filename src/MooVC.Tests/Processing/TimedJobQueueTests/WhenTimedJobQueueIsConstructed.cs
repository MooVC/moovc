﻿namespace MooVC.Processing.TimedJobQueueTests
{
    using System;
    using Moq;
    using Xunit;

    public sealed class WhenTimedJobQueueIsConstructed
    {
        [Fact]
        public void GivenATimerThenAnInstanceIsReturned()
        {
            var timer = new Mock<TimedProcessor>(TimeSpan.Zero, TimeSpan.Zero);
            _ = new TestTimedJobQueue(timer.Object);
        }

        [Fact]
        public void GivenNoTimerThenAnArgumentNullExceptionIsThrown()
        {
            TimedProcessor? timer = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new TestTimedJobQueue(timer!));

            Assert.Equal(nameof(timer), exception.ParamName);
        }
    }
}