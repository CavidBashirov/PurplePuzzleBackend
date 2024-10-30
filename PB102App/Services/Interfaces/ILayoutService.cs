namespace PB102App.Services.Interfaces
{
    public interface ILayoutService
    {
        Task<Dictionary<string, string>> GetAllSettingsAsync();
    }
}
