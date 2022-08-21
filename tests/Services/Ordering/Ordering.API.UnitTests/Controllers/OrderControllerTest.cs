using Xunit;
using Ordering.API.Controllers;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using Ordering.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Ordering.Application.Orders.Queries.GetOrdersList;
using MediatR;
using NSubstitute;
using FluentAssertions;

namespace Ordering.API.UnitTests.Controllers
{
    public class OrderControllerTest
    {
        private readonly OrderController _orderController;
        private readonly ISender _sender = Substitute.For<IMediator>();

        public OrderControllerTest()
        {
            _orderController = new OrderController();
        }

        [Fact]
        public async void GetOrdersByUserName_ShouldReturnOrders_WhenOrdersExist()
        {
            //Arrange
            var orders = GetOrders();
            var userName = orders.FirstOrDefault()?.UserName;
            var query = new GetOrdersListQuery(userName!);

            _sender.Send(query).Returns(orders);

            //Act
            var result = (OkObjectResult?)(await _orderController.GetOrdersByUserName(userName!)).Result;

            //Assert
            result?.StatusCode.Should().Be(200);
            result?.Value.Should().BeEquivalentTo(orders);
        }

        private new List<OrderDto> GetOrders()
        {
            return new List<OrderDto>
            {
                new OrderDto
                {
                    UserName="andrija",
                    TotalPrice=500,
                    FirstName="Andrija",
                    LastName="Mitrovic",
                    EmailAddress="andrija@gmail.com",
                    AddressLine="Jadranski put 48",
                    Country="Montenegro",
                    State="Montenegro",
                    ZipCode="8547",
                    CardName="Visa",
                    CardNumber="111111111111",
                    Expiration="10/22",
                    CVV="888",
                    PaymentMethod=(int)PaymentMethod.Card
                }
            };
        }
    }
}