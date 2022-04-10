using Microsoft.AspNetCore.Mvc;
using Net6WebApi2.DalCommon;
using Net6WebApi2.DTO;

namespace Net6WebApi2.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public class NotesController : ControllerBase
{
    private readonly ILogger<NotesController> _logger;
    private readonly INoteSrv _noteSrv;

    public NotesController(ILogger<NotesController> logger, INoteSrv srv)
    {
        _logger = logger;
        _noteSrv = srv;
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        return await _noteSrv.FindNote(id)
            is Net6WebApi2.DalCommon.Models.Note n
                ? Results.Ok(new Note(n))
                : Results.NotFound();
    }


    [HttpPost]
    public async Task<IResult> Post([FromBody]BaseNote n)
    {
        var nt = await _noteSrv.AddNoteAsync(new Net6WebApi2.DalCommon.Models.Note(n.text, n.done));
        return Results.Created($"/notes/{nt}", nt);
    }

}

