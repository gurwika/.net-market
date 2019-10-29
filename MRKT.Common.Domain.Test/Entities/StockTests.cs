using MRKT.Common.Domain.Entities.Production;
using MRKT.Common.Domain.Entities.Production.Events;
using MRKT.Common.Domain.Exceptions;
using MRKT.Common.Domain.ValueObjects;
using System;
using Xunit;

namespace MRKT.Common.Domain.Test.Entities
{
    public class StockTests
    {
        [Fact]
        public void ShouldRiseStockCreatedEvent()
        {
            var stock = new Stock(
                Guid.NewGuid(),
                "sku001",
                "SMALL",
                0,
                2900,
                false,
                Guid.NewGuid()
            );

            Assert.Equal("sku001", stock.Sku);
            Assert.Equal("SMALL", stock.Size);
            Assert.Equal(0, stock.Qunatity);
            Assert.Equal(2900, stock.Price);
            Assert.False(stock.CanPreOrder);
            Assert.Single(stock.PendingEvents);
            Assert.IsType<StockCreatedEvent>(stock.PendingEvents.Peek());
        }

        [Fact]
        public void ShouldRiseStockUpdatedEvent()
        {
            var stock = new Stock(
                Guid.NewGuid(),
                "sku001",
                "SMALL",
                0,
                2900,
                false,
                Guid.NewGuid()
            );

            stock.Update(
                "sku002",
                "MEDIUM",
                2999,
                true
            );

            Assert.Equal("sku002", stock.Sku);
            Assert.Equal("MEDIUM", stock.Size);
            Assert.Equal(2999, stock.Price);
            Assert.True(stock.CanPreOrder);

            Assert.Equal(2, stock.PendingEvents.Count);
            Assert.IsType<StockUpdatedEvent>(stock.PendingEvents.ToArray()[1]);
        }

        [Fact]
        public void ShouldRiseProductDetailInStockEvent()
        {
            var stock = new Stock(
                Guid.NewGuid(),
                "sku001",
                "SMALL",
                0,
                2900,
                false,
                Guid.NewGuid()
            );

            stock.UpdateQunatity(10);

            Assert.Equal(10, stock.Qunatity);
            Assert.Equal(2, stock.PendingEvents.Count);
            Assert.IsType<ProductDetailInStockEvent>(stock.PendingEvents.ToArray()[1]);
        }

        [Fact]
        public void ShouldRiseProductDetailOutOfStockEvent()
        {
            var stock = new Stock(
                Guid.NewGuid(),
                "sku001",
                "SMALL",
                10,
                2900,
                false,
                Guid.NewGuid()
            );

            stock.UpdateQunatity(0);

            Assert.Equal(0, stock.Qunatity);
            Assert.Equal(2, stock.PendingEvents.Count);
            Assert.IsType<ProductDetailOutOfStockEvent>(stock.PendingEvents.ToArray()[1]);
        }

        [Fact]
        public void ShouldRiseStockQuantityUpdatedEvent()
        {
            var stock = new Stock(
                Guid.NewGuid(),
                "sku001",
                "SMALL",
                10,
                2900,
                false,
                Guid.NewGuid()
            );

            stock.UpdateQunatity(9);

            Assert.Equal(9, stock.Qunatity);
            Assert.Equal(2, stock.PendingEvents.Count);
            Assert.IsType<StockQuantityUpdatedEvent>(stock.PendingEvents.ToArray()[1]);
        }

        [Fact]
        public void ShouldRiseStockDeletedEvent()
        {
            var stock = new Stock(
                Guid.NewGuid(),
                "sku001",
                "SMALL",
                0,
                2900,
                false,
                Guid.NewGuid()
            );

            stock.Delete();

            Assert.NotNull(stock.DeletedAt);
            Assert.Equal(2, stock.PendingEvents.Count);
            Assert.IsType<StockDeletedEvent>(stock.PendingEvents.ToArray()[1]);
        }
    }
}
