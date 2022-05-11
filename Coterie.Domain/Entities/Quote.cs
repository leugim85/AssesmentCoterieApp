namespace AssesmentCoterie.Domain.Entities
{
    public class Quote
    {
        public Guid TransactionId { get; set; }

        public string Business { get; set; }

        public double Revenue { get; set; }

        public bool IsSuccesful { get; set; }
    }
}
