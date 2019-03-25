namespace Mews.Fiscalization.Uniwix.Dto
{
    public enum SdiState
    {
        Pending = 0,
        Delivered = 1,
        DeliveryFailed = 2,
        RejectedBySdi = 3,
        DeliveryImpossible = 4,
        DeadlinePassed = 5,
        AcceptedByClient = 6,
        RejectedByClient = 7
    }
}