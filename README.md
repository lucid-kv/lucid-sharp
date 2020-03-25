# lucid-sharp

Lucid KV wrapper for the C# language.

### Dependency Injection

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddLucidCache(options =>
    {
        options.Configuration = "https://lucid-kv.herokuapp.com/";
        options.InstanceName = "SampleInstance";
    });

    services.AddControllers();
}
```
