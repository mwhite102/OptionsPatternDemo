# IOptions Pattern Demo in ASP.NET 6

A simple demo that loads application options from a section in the appsettings.json file.

[Reference](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0)

To implement the IOptions Pattern start with adding a section to the appsettings.json file:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AppOptions": {
    "Option1": "Option1Value",
    "Option2": "Option2Value"
  },
  "AllowedHosts": "*"
}
```

Next, add model class for the options:

```C#
namespace OptionsPattern.Web.OptionModels
{
    public class AppOptionsModel
    {
        /// <summary>
        /// This is here so we don't have to have a literal sting in Program.cs
        /// when the "AppOptions" section is loaded from appsettings.json
        /// </summary>
        public const string AppOptions = "AppOptions";

        public string Option1 { get; set; } = String.Empty;
        public string Option2 { get; set; } = String.Empty;
    }
}
```

In Program.cs, load the settings from the appsettings.json file:

```C#
// Load application options from the "AppOptions" section in appsettings.json
builder.Services.Configure<AppOptionsModel>(builder.Configuration.GetSection(AppOptionsModel.AppOptions));
```

The options are injected into a page wrapped in a generic IOptionsSnapshot\<T>:

```C#
private readonly ILogger<IndexModel> _logger;
        private readonly AppOptionsModel _options;

        /// <summary>
        /// IndexModel constructor
        /// </summary>
        /// <param name="logger">The ILogger instance</param>
        /// <param name="options">The IOptionsSnapshot instance with options loaded from appsettings.json</param>
        public IndexModel(ILogger<IndexModel> logger, IOptionsSnapshot<AppOptionsModel> options)
        {
            _logger = logger;
            _options = options.Value;
        }
```

IOptionsSnapshot\<T> is scoped to each request and changes to appsettings.json are read for each request.

For a singleton instance of options, use IOptions\<T> instead.
