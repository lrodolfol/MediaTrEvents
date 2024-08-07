using MediaTr.Manager.Model.Entities;
using MediaTr.Manager.Model.Enuns;

namespace MediaTr.Manager.Model.Agreggates;

public struct Order(User user, Payment payment, Status status)
{
    public User User { get; private set; } = user;
    public Payment Payment { get; private set; } = payment;
    public Status Status { get; private set; } = status;
    public DateTime TimeOrder { get; private set; } = DateTime.UtcNow;
    public List<ErrorDescription> ErrorDescription { get; private set; } = [];

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(User.Name))
            ErrorDescription.Add(Enuns.ErrorDescription.InvalidNameUser);
        if (string.IsNullOrWhiteSpace(User.Email))
            ErrorDescription.Add(Enuns.ErrorDescription.InvalidEmailUser);
        if (TimeOrder == DateTime.MinValue || TimeOrder == DateTime.MaxValue)
            ErrorDescription.Add(Enuns.ErrorDescription.InvalidTimeOrder);
    }
}
