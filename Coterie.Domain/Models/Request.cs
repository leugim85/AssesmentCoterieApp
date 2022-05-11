namespace AssesmentCoterie.Domain.Models
{
    public class Request
    {
        public string Business { get; set; }

        public double Revenue { get; set; }

        public List<string> States { get; set; }
    }
}
