using System;

namespace Net6WebApi2.DTO
{
    public record Note : BaseNote
    {
        public Note() : base()
        {
        }

        public Note(string? text, bool done) : base(text, done)
        {

        }

        public Note(DalCommon.Models.Note n) : this(n.id, n.text, n.done)
        {

        }

        public Note(int id, string? text, bool done) : base(text, done)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}

