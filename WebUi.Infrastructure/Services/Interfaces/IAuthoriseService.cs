namespace WebUi.Infrastructure.Services.Interfaces;

public interface IAuthoriseService
{
    Task<string> AuthoriseAndTakeTokenAsync();
}
