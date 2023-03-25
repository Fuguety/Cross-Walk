namespace TextGameBase.Entities
{
    internal class Response
    {
        public int Sequence { get; set; }

        public string? Text { get; set; }

        public int TargetId { get; set; }

        public Item Item { get; set; }
    }
}