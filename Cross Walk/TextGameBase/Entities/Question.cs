namespace TextGameBase.Entities
{
    internal class Question
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public List<Response>? Responses { get; set; }
    }
}