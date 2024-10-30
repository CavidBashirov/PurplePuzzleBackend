using PB102App.ViewModels.Admin.Work;

namespace PB102App.Services.Interfaces
{
    public interface IWorkService
    {
        Task<IEnumerable<WorkVM>> GetAllAsync();
        Task<SingleWorkVM> GetByIdAsync(int id);
    }
}
