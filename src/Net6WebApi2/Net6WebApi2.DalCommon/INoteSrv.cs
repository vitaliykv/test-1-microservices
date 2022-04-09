using Net6WebApi2.DalCommon.Models;

namespace Net6WebApi2.DalCommon;

public interface INoteSrv
{
    Task<int> AddNoteAsync(Note n);
    Task<Note?> FindNote(int id);
}

