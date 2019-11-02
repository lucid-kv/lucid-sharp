# lucid-csharp

Lucid wrapper for the C# language.

### Dependency Injection

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddLucid(options =>
    {
        options.Endpoint = "http://localhost:7021/api/";
    });

    services.AddControllers();
}
```
