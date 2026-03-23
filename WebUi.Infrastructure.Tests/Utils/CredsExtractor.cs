using Microsoft.Extensions.Configuration;
using WebUi.Infrastructure.Models;

namespace WebUi.Infrastructure.Tests.Utils;

internal static class CredsExtractor
{
    internal static AstridsoftOptions Extract(IConfiguration configs)
    {
        return new AstridsoftOptions
        {
            AuthoriseEndpoint = new Uri(configs["AstridsoftOptions:ApiUrl"] ?? throw new InvalidOperationException()),
            UserAuth = new UserDto
            {
                Login = configs["AstridsoftOptions:Account:login"] ?? throw new InvalidOperationException(),
                Password = configs["AstridsoftOptions:Account:password"] ?? throw new InvalidOperationException()
            }
        };
    }
}
