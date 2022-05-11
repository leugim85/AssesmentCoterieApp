namespace AssesmentCoterie.Domain.Models
{
    public class QuoteDto
    {
        public Guid TransactionId { get; set; }

        public string Business { get; set; }

        public double Revenue { get; set; }

        public bool IsSuccesful { get; set; }

        public List<Premiums> Premiums { get; set; }
    }
}
