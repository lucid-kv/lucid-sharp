<p align="center">
  <p align="center">
    <img src="https://github.com/lucid-kv/deploy-templates/blob/master/lucid.png?raw=true" height="100" alt="Lucid KV" />
  </p>
  <h3 align="center">
    lucid-sharp
  </h3>
  <p align="center">
    Lucid KV Client for C# / .NetCore Language
  </p>
  <p align="center">
    <a href="https://github.com/lucid-kv/lucid/actions?workflow=Lucid"><img src="https://github.com/lucid-kv/lucid/workflows/Lucid/badge.svg" /></a>
    <a href="https://www.rust-lang.org/"><img src="https://img.shields.io/badge/Made%20With-Rust-dea584" /></a>
    <a href="https://github.com/lucid-kv/lucid/blob/master/LICENSE.md"><img src="https://img.shields.io/badge/license-MIT-lightgrey.svg" /></a>
    <a href="https://discord.gg/mZz67M6"><img src="https://img.shields.io/badge/Discord-Server-7289DA" /></a>
  </p>
</p>

## How to Use?

You simply need to add this lines to `Startup.cs` file:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddLucidCache(options =>
    {
        options.Configuration = "https://lucid-kv.herokuapp.com/";
        options.InstanceName = "LucidPublicNode";
    });

    services.AddControllers();
}
```

### Consume it with dependency injection (DI)

```csharp
public class HomeController : Controller
{
    private readonly IDistributedCache _distributedCache;

    public HomeController(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public IActionResult Index()
    {
        // Store String
        // Hello World! is written in https://lucid-kv.herokuapp.com/api/kv/hello_world
        _distributedCache.SetString("hello_world", "Hello World!");        

        // Directly store an image
        _distributedCache.Set("hello_world", System.IO.File.ReadAllBytes("/tmp/profile_picture.jpg"));
        return View();
    }
}
```
