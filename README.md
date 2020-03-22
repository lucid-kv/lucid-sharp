# lucid-csharp

Lucid KV wrapper for the C# language.

### Dependency Injection

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddLucid(options =>
    {
        options.Endpoint = "https://lucid-kv.herokuapp.com/";
    });

    services.AddControllers();
}
```
