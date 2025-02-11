using Bogus;
using CDB.Domain.Services.Dtos;

namespace CDB.UnitTests.Mocks;

public static class PostCdbResponseMock
{
    public static PostCdbResponse GetDefaultInstance()
    {
        return new Faker<PostCdbResponse>("pt_BR")
            .RuleFor(fake => fake.Gross, faker => faker.Random.Decimal(1100, 20000))
            .RuleFor(fake => fake.Net, faker => faker.Random.Decimal(1000, 19000));
    }
}