﻿namespace MooVC.Persistence.MappedStoreTests
{
    using System;
    using MooVC.Linq;
    using Moq;
    using Xunit;

    public sealed class WhenGetAsyncIsCalled
        : MappedStoreTests
    {
        [Fact]
        public async void GivenAKeyThenTheInnerMappingAndInnerStoreAreInvokedAsync()
        {
            bool wasInvoked = false;
            string? expectedInnerKey = default;

            string LocalInnerMapping(Guid key)
            {
                wasInvoked = true;

                expectedInnerKey = InnerMapping(key);

                return expectedInnerKey;
            }

            var outterKey = Guid.NewGuid();
            object expectedItem = new object();

            _ = Store
                .Setup(store => store.GetAsync(It.Is<string>(parameter => parameter == expectedInnerKey)))
                .ReturnsAsync(expectedItem);

            var store = new MappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store.Object);

            object? actualItem = await store.GetAsync(outterKey);

            Assert.True(wasInvoked);
            Assert.Equal(expectedItem, actualItem);

            Store.Verify(store => store.GetAsync(It.IsAny<string>()), times: Times.Once);
        }

        [Fact]
        public async void GivenPagingThenTheInnerStoreIsInvokedAsync()
        {
            var paging = new Paging();

            var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

            _ = await store.GetAsync(paging: paging);

            Store.Verify(store => store.GetAsync(It.IsAny<Paging>()), times: Times.Once);
        }
    }
}