namespace WebUi.Infrastructure.Services.Interfaces;

public interface IDataCollector
{
    Task<Dictionary<string, object>> CollectDataAsync();
}
