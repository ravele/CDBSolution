using Bogus;
using CDB.Domain.Services.Dtos;

namespace CDB.UnitTests.Mocks;

public static class PostCdbRequestMock
{
    public static PostCdbRequest GetDefaultInstance()
    {
        return new Faker<PostCdbRequest>("pt_BR")
            .RuleFor(fake => fake.InitialValue, faker => faker.Random.Decimal(1000, 10000))
            .RuleFor(fake => fake.Months, faker => faker.Random.Int(2, 36));
    }
}