namespace OptionsPattern.Web.OptionModels
{
    public class AppOptionsModel
    {
        /// <summary>
        /// This is here so we don't have to have a literal sting in Program.cs
        /// when the "AppOptions" section is loaded from appsettings.json
        /// </summary>
        public const string AppOptions = "AppOptions";

        /// <summary>
        /// Gets or sets the Option1 value
        /// </summary>
        public string Option1 { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the Option2 value
        /// </summary>
        public string Option2 { get; set; } = String.Empty;
    }
}
