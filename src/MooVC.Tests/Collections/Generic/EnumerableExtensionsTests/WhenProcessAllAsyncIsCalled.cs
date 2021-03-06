﻿namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenProcessAllAsyncIsCalled
    {
        [Fact]
        public async Task GivenANullSourceWhenAnEnumerableResultTransformIsProvidedThenAnEmptySetOfResultsIsReturnedAsync()
        {
            IEnumerable<int>? source = default;

            IEnumerable<int> results = await source.ProcessAllAsync(
                async value => await Task.FromResult(new[] { value }.AsEnumerable()));

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public async Task GivenANullSourceWhenATransformIsProvidedThenAnEmptySetOfResultsIsReturnedAsync()
        {
            IEnumerable<int>? source = default;

            IEnumerable<int> results = await source.ProcessAllAsync(
                async value => await Task.FromResult(value));

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public async Task GivenANullSourceWhenNoEnumerableResultTransformIsProvidedThenNoArgumentNullExceptionIsThrownAsync()
        {
            IEnumerable<int>? source = default;
            Func<int, Task<IEnumerable<int>>>? transform = default;

            IEnumerable<int> results = await source.ProcessAllAsync(transform!);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public async Task GivenANullSourceWhenNoTransformIsProvidedThenNoArgumentNullExceptionIsThrownAsync()
        {
            IEnumerable<int>? source = default;
            Func<int, Task<int>>? transform = default;

            IEnumerable<int> results = await source.ProcessAllAsync(transform!);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public async Task GivenASourceWhenAnEnumerableResultTransformIsProvidedThenResultsForThatSourceAreReturnedAsync()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };

            IEnumerable<int> results = await source.ProcessAllAsync(
                async value => await Task.FromResult(new[] { value * value }.AsEnumerable()));

            Assert.NotNull(results);
            Assert.Contains(results, element => expected.Contains(element));
            Assert.Equal(expected.Count(), results.Count());
        }

        [Fact]
        public async Task GivenASourceWhenATransformIsProvidedThenResultsForThatSourceAreReturnedAsync()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };

            IEnumerable<int> results = await source.ProcessAllAsync(
                async value => await Task.FromResult(value * value));

            Assert.NotNull(results);
            Assert.Contains(results, element => expected.Contains(element));
            Assert.Equal(expected.Count(), results.Count());
        }

        [Fact]
        public async Task GivenASourceWhenNoEnumerableResultTransformIsProvidedThenAnArgumentExceptionIsThrownAsync()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            Func<int, Task<IEnumerable<int>>>? transform = default;

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => source.ProcessAllAsync(transform!));

            Assert.Equal(nameof(transform), exception.ParamName);
        }

        [Fact]
        public async Task GivenASourceWhenNoTransformIsProvidedThenAnArgumentExceptionIsThrownAsync()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            Func<int, Task<int>>? transform = default;

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => source.ProcessAllAsync(transform!));

            Assert.Equal(nameof(transform), exception.ParamName);
        }
    }
}