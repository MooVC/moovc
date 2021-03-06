﻿namespace MooVC.Diagnostics.DiagnosticsEmittedEventArgsExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenThrowIsCalled
    {
        [Fact]
        public void GivenAnEmptySourceWhenANullPredicateIsProvidedThenAnArgumentNullExceptionIsThrown()
        {
            IEnumerable<DiagnosticsEmittedEventArgs>? source = new DiagnosticsEmittedEventArgs[0];
            Func<DiagnosticsEmittedEventArgs, Exception, bool>? predicate = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => source.Throw(predicate!));

            Assert.Equal(nameof(predicate), exception.ParamName);
        }

        [Fact]
        public void GivenAnEmptySourceWhenNoPredicateIsProvidedThenNoAggregateExceptionIsThrown()
        {
            IEnumerable<DiagnosticsEmittedEventArgs>? source = new DiagnosticsEmittedEventArgs[0];

            source.Throw();
        }

        [Fact]
        public void GivenAnNullSourceThenNoAggregateExceptionIsThrown()
        {
            IEnumerable<DiagnosticsEmittedEventArgs>? source = default;

            source.Throw();
        }

        [Fact]
        public void GivenASourceWhenALevelIsProvidedThenAnAggregateExceptionIsThrownWithTheExpectedDiagnosticsAsTheCause()
        {
            IEnumerable<DiagnosticsEmittedEventArgs> expected = new[]
            {
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Critical),
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Error),
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Warning),
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Information),
            };

            IEnumerable<DiagnosticsEmittedEventArgs> unexpected = new[]
            {
                new DiagnosticsEmittedEventArgs(level: Level.Critical),
                new DiagnosticsEmittedEventArgs(level: Level.Error),
                new DiagnosticsEmittedEventArgs(level: Level.Warning),
                new DiagnosticsEmittedEventArgs(level: Level.Information),
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Debug),
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Trace),
            };

            IEnumerable<DiagnosticsEmittedEventArgs> source = expected.Union(unexpected);

            AggregateException exception = Assert.Throws<AggregateException>(
                () => source.Throw(level: Level.Information));

            Assert.Equal(expected.Select(expected => expected.Cause), exception.InnerExceptions);
        }

        [Fact]
        public void GivenASourceWhenAPredicateIsProvidedThenAnAggregateExceptionIsThrownWithTheExpectedDiagnosticsAsTheCause()
        {
            const string ExpectedMessage = "Test";

            IEnumerable<DiagnosticsEmittedEventArgs> source = new[]
            {
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Critical),
                new DiagnosticsEmittedEventArgs(cause: new Exception(ExpectedMessage), level: Level.Error),
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Warning),
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Information),
                new DiagnosticsEmittedEventArgs(level: Level.Critical),
                new DiagnosticsEmittedEventArgs(level: Level.Error),
                new DiagnosticsEmittedEventArgs(level: Level.Warning),
                new DiagnosticsEmittedEventArgs(level: Level.Information),
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Debug),
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Trace),
            };

            AggregateException exception = Assert.Throws<AggregateException>(
                () => source.Throw((_, cause) => cause.Message == ExpectedMessage));

            Exception expected = Assert.Single(exception.InnerExceptions);
            Assert.Equal(ExpectedMessage, expected.Message);
        }

        [Fact]
        public void GivenASourceAndAMessageWhenALevelIsProvidedThenAnAggregateExceptionIsThrownWithAMatchingMessage()
        {
            const string ExpectedMessage = "Something something Dark Side";

            IEnumerable<DiagnosticsEmittedEventArgs> source = new[]
            {
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Critical),
            };
            AggregateException exception = Assert.Throws<AggregateException>(
                () => source.Throw(level: Level.Trace, message: ExpectedMessage));

            Assert.StartsWith(ExpectedMessage, exception.Message);
        }

        [Fact]
        public void GivenASourceAndAMessageWhenAPredicateIsProvidedThenAnAggregateExceptionIsThrownWithAMatchingMessage()
        {
            const string ExpectedMessage = "Something something Dark Side";

            IEnumerable<DiagnosticsEmittedEventArgs> source = new[]
            {
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Critical),
            };
            AggregateException exception = Assert.Throws<AggregateException>(
                () => source.Throw((_, _) => true, message: ExpectedMessage));

            Assert.StartsWith(ExpectedMessage, exception.Message);
        }

        [Fact]
        public void GivenASourceAndAMessageWhenNoLevelIsProvidedThenAnAggregateExceptionIsThrownWithAMatchingMessage()
        {
            const string ExpectedMessage = "Something something Dark Side";

            IEnumerable<DiagnosticsEmittedEventArgs> source = new[]
            {
                new DiagnosticsEmittedEventArgs(cause: new Exception(), level: Level.Critical),
            };
            AggregateException exception = Assert.Throws<AggregateException>(
                () => source.Throw(message: ExpectedMessage));

            Assert.StartsWith(ExpectedMessage, exception.Message);
        }
    }
}