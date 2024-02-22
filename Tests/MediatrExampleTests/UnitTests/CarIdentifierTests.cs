using AutoFixture;
using FluentAssertions;
using MediatR;
using MediatrExample.Models;
using MediatrExample.Services;
using Moq;

namespace Tests.MediatrExampleTests.UnitTests;

public class CarIdentifierTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<IMediator> _mediatorMock = new();

    public CarIdentifierTests()
    {
        _mediatorMock.Setup(x => x.Send(It.IsAny<CarIdentificationContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((CarIdentificationContext x, CancellationToken arg2) =>
                new CarIdentificationResult { Type = x.Car.Model, Match = true });
    }

    [Fact]
    public async Task IdentifyCars_Statistic_Correct()
    {
        // arrange
        var cars = _fixture.Build<Car>().CreateMany(10).ToList();
        _mediatorMock.Setup(x => x.Send(It.IsAny<CarIdentificationContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((CarIdentificationContext x, CancellationToken arg2) =>
                new CarIdentificationResult { Type = x.Car.Model, Match = true });

        var identifier = new CarIdentifier(_mediatorMock.Object);

        // act 
        var statistic = await identifier.IdentifyCars(cars);

        // assert
        var myStatistic = new Dictionary<CarModelType, int>();
        foreach (var car in cars.Where(car => !myStatistic.TryAdd(car.Model, 1))) myStatistic[car.Model]++;

        foreach (var model in myStatistic.Keys) statistic[model].Should().Be(myStatistic[model]);
    }
}