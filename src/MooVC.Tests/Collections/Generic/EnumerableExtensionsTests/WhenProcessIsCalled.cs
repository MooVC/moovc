﻿namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenProcessIsCalled
    {
        [Fact]
        public void GivenANullSourceWhenATransformIsProvidedThenAnEmptySetOfResultsIsReturned()
        {
            IEnumerable<int>? source = null;
            IEnumerable<int> results = source.Process(value => value);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenANullSourceWhenAnEnumerableResultTransformIsProvidedThenAnEmptySetOfResultsIsReturned()
        {
            IEnumerable<int>? source = null;
            IEnumerable<int> results = source.Process(value => new[] { value }.AsEnumerable());

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenANullSourceWhenNoEnumerableResultTransformIsProvidedThenAnEmptySetOfResultsIsReturned()
        {
            IEnumerable<int>? source = null;
            Func<int, IEnumerable<int>>? transform = default;
            IEnumerable<int> results = source.Process(transform!);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenANullSourceWhenNoTransformIsProvidedThenNoArgumentNullExceptionIsThrown()
        {
            IEnumerable<int>? source = null;
            Func<int, int>? transform = default;
            IEnumerable<int> results = source.Process(transform!);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenASourceWhenAnEnumerableResultTransformIsProvidedThenResultsForThatSourceAreReturned()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };
            IEnumerable<int> results = source.Process(value => new[] { value * value }.AsEnumerable());

            Assert.NotNull(results);
            Assert.Equal(expected, results);
        }

        [Fact]
        public void GivenASourceWhenATransformIsProvidedThenResultsForThatSourceAreReturned()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };
            IEnumerable<int> results = source.Process(value => value * value);

            Assert.NotNull(results);
            Assert.Equal(expected, results);
        }

        [Fact]
        public void GivenASourceWhenNoEnumerableResultTransformIsProvidedThenAnArgumentExceptionIsThrown()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            Func<int, IEnumerable<int>>? transform = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => source.Process(transform!));

            Assert.Equal(nameof(transform), exception.ParamName);
        }

        [Fact]
        public void GivenASourceWhenNoTransformIsProvidedThenAnArgumentExceptionIsThrown()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            Func<int, int>? transform = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => source.Process(transform!));

            Assert.Equal(nameof(transform), exception.ParamName);
        }

        [Fact]
        public void GivenASourceWhenATransformIsProvidedThatReturnsANullResponseThenResultsReturnedAreEmpty()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<object> results = source.Process(value => default(object)!);

            Assert.NotNull(results);
            Assert.Empty(results);
        }
    }
}