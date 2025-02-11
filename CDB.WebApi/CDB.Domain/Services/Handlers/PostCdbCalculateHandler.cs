using CDB.Domain.Services.Contracts;
using CDB.Domain.Services.Dtos;

namespace CDB.Domain.Services.Handlers;

public class PostCdbCalculateHandler : IPostCdbCalculate
{
    private const decimal CDI = 0.009m; // CDI fixo (0.9%)
    private const decimal TB = 1.08m; // Taxa do Banco (108%)

    public Task<ServiceResult> HandleAsync(PostCdbRequest request, CancellationToken cancellationToken)
    {
        if (request.InitialValue <= 0 || request.Months < 2)
        {
            return Task.FromResult(new ServiceResult(400, "Initial value must be greater than 0 and months must be at least 2."));
        }

        var grossAmount = CalculateGrossAmount(request.InitialValue, request.Months);
        var netAmount = CalculateNetAmount(grossAmount, request.Months, request.InitialValue);

        var response = new PostCdbResponse
        {
            Gross = grossAmount,
            Net = netAmount
        };

        return Task.FromResult(new ServiceResult(200, response));
    }

    private decimal CalculateGrossAmount(decimal initialValue, int months)
    {
        decimal value = initialValue;
        for (int i = 0; i < months; i++)
        {
            value *= 1 + (CDI * TB);
        }
        return Math.Round(value, 2);
    }

    private decimal CalculateNetAmount(decimal grossAmount, int months, decimal initialValue)
    {
        decimal taxRate = GetTaxRate(months);
        decimal profit = grossAmount - initialValue;
        decimal tax = profit * taxRate;
        return Math.Round(grossAmount - tax, 2);
    }

    private decimal GetTaxRate(int months)
    {
        if (months <= 6) return 0.225m;
        if (months <= 12) return 0.20m;
        if (months <= 24) return 0.175m;
        return 0.15m;
    }
}