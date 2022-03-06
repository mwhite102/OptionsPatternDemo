using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using OptionsPattern.Web.OptionModels;

namespace OptionsPattern.Web.Pages
{
    public class IndexModel : PageModel
    {
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

        /// <summary>
        /// Gets the AppOptionsModel
        /// </summary>
        public AppOptionsModel AppOptions => _options;

        public void OnGet()
        {
            
        }
    }
}