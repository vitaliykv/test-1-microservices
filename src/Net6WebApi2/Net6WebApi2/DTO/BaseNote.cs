namespace Net6WebApi2.DTO
{
    public record BaseNote
    {
        public BaseNote()
        {
        }

        public BaseNote(string? text, bool done)
        {
            this.text = text;
            this.done = done;
        }

        public string? text { get; set; }
        public bool done { get; set; }
    }
}

