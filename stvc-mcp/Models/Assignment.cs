using System;
using System.Collections.Generic;
using System.Text;

namespace stvc_mcp.Models;

public record Assignment
{
    public string Title { get; init; } = "";
    public string Url { get; init; } = "";
    public string Status { get; init; } = "";
    public bool Graded { get; init; }
}
