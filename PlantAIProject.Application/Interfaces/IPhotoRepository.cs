// PlantAIProject.Application/Interfaces/IPhotoRepository.cs
using PlantAIProject.Domain.Entities;

namespace PlantAIProject.Application.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo> AddAsync(Photo photo);
        Task<Photo?> GetByIdAsync(int id);
        Task<IEnumerable<Photo>> GetAllAsync();
        Task<IEnumerable<Photo>> GetRecentAsync(int count = 10);
        Task UpdateAsync(Photo photo);
        Task DeleteAsync(int id);
    }
}