using ModelContextProtocol.Server;
using System.ComponentModel;

[McpServerToolType]
public class LoginTool
{
    private readonly LmsClient _client;
    public LoginTool(LmsClient client) => _client = client;

    [McpServerTool, Description("ورود به سامانه سمیاد")]
    public async Task<string> Login(
        [Description("نام کاربری")] string username,
        [Description("رمز عبور")]   string password)
    {
        await _client.LoginAsync(username, password);
        return "ورود موفق";
    }
}