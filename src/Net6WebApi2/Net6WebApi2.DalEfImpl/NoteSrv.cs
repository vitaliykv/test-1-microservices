using Net6WebApi2.DalCommon;
using Net6WebApi2.DalCommon.Models;

namespace Net6WebApi2.DalEfImpl
{

    public class NoteSrv : INoteSrv
    {
        private NoteDbContext.NoteDbContext db;

        public NoteSrv(NoteDbContext.NoteDbContext context)
        {
            db = context;
        }

        #region INoteSrv

        public async Task<int> AddNoteAsync(Note n)
        {
            var ne = new DalEfImpl.Models.Note() { done = n.done, text = n.text };
            db.Notes.Add(ne);
            await db.SaveChangesAsync();
            return ne.id;
        }

        public async Task<Note?> FindNote(int id)
        {
            var ne = await db.Notes.FindAsync(id);
            return ne != null ? new Note(ne.id, ne.text, ne.done) : null;
        }

        #endregion INoteSrv
    }
}




