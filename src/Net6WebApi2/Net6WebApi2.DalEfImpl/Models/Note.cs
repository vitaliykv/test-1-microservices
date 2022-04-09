using System;
namespace Net6WebApi2.DalEfImpl.Models
{
	public class Note
    {
        public int id { get; set; }
        public string? text { get; set; }
        public bool done { get; set; }
    }
}

