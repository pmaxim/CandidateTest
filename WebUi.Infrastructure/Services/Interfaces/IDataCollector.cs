using WebUi.Infrastructure.Models.AstridsoftDtos;

namespace WebUi.Infrastructure.Services.Interfaces;

public interface IDataCollector
{
    Task<AstridsoftRootDto> CollectDataAsync();
}
