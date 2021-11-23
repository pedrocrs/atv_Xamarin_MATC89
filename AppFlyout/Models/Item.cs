using System;

namespace AppFlyout.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public string Ano { get; set; }
        public Int32 QtdOscars { get; set; }
        public string Atores { get; set; }
    }
}