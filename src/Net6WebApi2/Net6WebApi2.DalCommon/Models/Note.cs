using System;
namespace Net6WebApi2.DalCommon.Models
{
    public record Note
    {
        public Note(string? text, bool done)
        {
            this.text = text;
            this.done = done;
        }

        public Note(int id, string? text, bool done)
        {
            this.id = id;
            this.text = text;
            this.done = done;
        }

        public int id { get; set; }
        public string? text { get; set; }
        public bool done { get; set; }
    }
}

