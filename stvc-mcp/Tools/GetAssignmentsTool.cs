using ModelContextProtocol.Server;
using System.ComponentModel;

[McpServerToolType]
public class GetAssignmentsTool
{
    private readonly LmsClient _client;
    public GetAssignmentsTool(LmsClient client) => _client = client;

    [McpServerTool, Description("لیست تکالیف تمام درس‌ها را برمی‌گرداند")]
    public async Task<string> GetAllAssignments()
    {
        var courses = await _client.GetCourseSlugsAsync();
        var results = new List<string>();

        foreach (var course in courses)
        {
            var assignments = await _client.GetAssignmentsAsync(course);
            foreach (var a in assignments)
                results.Add($"[{course}] {a.Title} | {a.Status} | {(a.Graded ? "تصحیح شده" : "تصحیح نشده")} | {a.Url}");
        }

        return results.Count == 0 ? "تکلیفی یافت نشد." : string.Join("\n", results);
    }
}