using HtmlAgilityPack;
using stvc_mcp.Models;

public class LmsClient
{
    private readonly HttpClient _http;
    private const string Base = "https://lms11.tvu.ac.ir";

    public LmsClient(HttpClient http) => _http = http;

    public async Task LoginAsync(string username, string password)
    {
        var form = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["username"] = username,
            ["password"] = password,
            ["login"]    = "true"
        });
        var res = await _http.PostAsync($"{Base}/login", form);
        res.EnsureSuccessStatusCode();
    }

    public async Task<List<Assignment>> GetAssignmentsAsync(string courseSlug)
    {
        var html = await _http.GetStringAsync($"{Base}/student/{courseSlug}");
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        return doc.DocumentNode
            .SelectNodes("//tr[contains(@id,':homework:')]")
            ?.Select(row => new Assignment
            {
                Title  = row.SelectSingleNode(".//a[contains(@href,'homework')]")?.InnerText.Trim() ?? "",
                Url    = Base + "/" + row.SelectSingleNode(".//a[contains(@href,'homework')]")?.GetAttributeValue("href",""),
                Status = row.SelectSingleNode(".//.//span[contains(@class,'badge-primary')]") != null
                         ? "ارسال شده"
                         : "ارسال نشده",
                Graded = row.SelectSingleNode(".//.//span[contains(@class,'badge-danger')]") == null
            })
            .ToList() ?? [];
    }

    public async Task<List<string>> GetCourseSlugsAsync()
    {
        var html = await _http.GetStringAsync($"{Base}/student/");
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        return doc.DocumentNode
            .SelectNodes("//a[contains(@href,'course-')]")
            ?.Select(a => a.GetAttributeValue("href", "").Trim('/'))
            .Where(h => h.StartsWith("course-"))
            .Distinct()
            .ToList() ?? [];
    }
}

