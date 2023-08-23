using System.Diagnostics.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Promocode.Application.Commands.CreatePromocode.Dtos;
using Promocode.DomainServices.Interfaces;

namespace Promocode.Application.Commands.CreatePromocode;

public class CreatePromocodeCommandHandler : IRequestHandler<CreatePromocodeCommand, CreatePromocodeCommandResult>
{
    private readonly IPromocodeDomainService _promocodeDomainService;
    private readonly ILogger<CreatePromocodeCommandHandler> _logger;

    public CreatePromocodeCommandHandler(
        IPromocodeDomainService promocodeDomainService,
        ILogger<CreatePromocodeCommandHandler> logger)
    {
        _promocodeDomainService = promocodeDomainService;
        _logger = logger;
    }

    public async Task<CreatePromocodeCommandResult> Handle(CreatePromocodeCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("CreatePromocodeCommand handled.");

        var result = _promocodeDomainService.CreatePromocode();
        CreatePromocodeCommandResult response = new CreatePromocodeCommandResult();
        

        return response;
    }
}