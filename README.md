# STVC MCP
یک سرور MCP برای دانشگاه ملی مهارت،
این پروژه چند ابزار در اختیار کلاینت‌های سازگار با MCP قرار می‌دهد تا بتوانند به اطلاعات موجود در سمیاد دسترسی داشته باشند.

## قابلیت‌ها

* ورود به حساب کاربری سمیاد
* مدیریت خودکار Session
* دریافت اطلاعات دروس
* دریافت تکالیف و فعالیت‌ها
* استفاده از طریق Claude Desktop، Cursor و سایر MCP Clientها

## نصب

```bash
git clone https://github.com/atymri/stvc-mcp.git
cd stvc-mcp
dotnet restore
```

## اجرا

```bash
dotnet run
```

## اتصال به Claude Desktop
از طریق settings وارد بخش Developer شده و روی Edit Config کلیک کنید و کد زیر را به فایل json اضافه کنید.

```json
{
  "mcpServers": {
    "stvc": {
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "/path/to/stvc-mcp"
      ]
    }
  }
}
```

## وضعیت پروژه

این پروژه هنوز در حال توسعه است و ممکن است بعضی قابلیت‌ها تغییر کنند یا کامل نباشند.
> [!WARNING]
> این پروژه یک پروژه شخصی و مستقل است و هیچ ارتباطی با دانشگاه ملی مهارت یا تیم توسعه سمیاد ندارد.


## License

MIT
