using Bogus;
using MediaTr.Manager.Model.Agreggates;
using MediaTr.Manager.Model.Entities;
using MediaTr.Manager.Model.Enuns;

namespace MediaTr.Manager.Mock;

public readonly struct CreateOrder(Faker faker)
{
    private readonly Faker _faker = faker;

    public Order Create() =>
        new (CreateUser(), CreatePayment(), Status.Delivered);

    private User CreateUser() =>
        new(_faker.Person.FullName, _faker.Person.Email);

    private Payment CreatePayment()
    {
        var random = new Random();
        var sorted = random.Next(1, Enum.GetValues(typeof(Payment)).Length);

        return (Payment)sorted;
    }
}
