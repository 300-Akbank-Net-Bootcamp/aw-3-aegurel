using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Schema;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountTransactionsController : ControllerBase
{
    private readonly IMediator mediator;
    public AccountTransactionsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse<List<AccountTransactionResponse>>> Get()
    {
        var operation = new GetAllAccountTransactionQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<AccountTransactionResponse>> Get(int id)
    {
        var operation = new GetAccountTransactionByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<ApiResponse<AccountTransactionResponse>> Post([FromBody] AccountTransactionRequest AccountTransaction)
    {
        var operation = new CreateAccountTransactionCommand(AccountTransaction);
        var result = await mediator.Send(operation);
        return result;
    }
}