using MediatR;
using MediatrExample.Models;

namespace MediatrExample.Services;

public class CarIdentificationContext : IRequest<CarIdentificationResult>
{
    public Car Car { get; set; } = null!;
}