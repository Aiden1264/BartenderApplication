using System;

namespace BartenderApplication.Models
{
    public class CocktailOrder
    {
        public int Id { get; set; }

        public string PatronName { get; set; }

        public string CocktailName { get; set; }

        public DateTime OrderTime { get; set; } = DateTime.Now;

        public OrderStatus Status { get; set; } = OrderStatus.Queued;

        public string? Notes { get; set; }
    }

    public enum OrderStatus
    {
        Queued,
        Preparing,
        ReadyForPickup
    }
}
