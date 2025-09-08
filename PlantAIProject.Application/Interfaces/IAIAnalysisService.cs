// PlantAIProject.Application/Interfaces/IAIAnalysisService.cs
using PlantAIProject.Domain.ValueObjects;

namespace PlantAIProject.Application.Interfaces
{
    public interface IAIAnalysisService
    {
        Task<AnalysisResult> AnalyzeImageAsync(byte[] imageData, string fileName);
        string ProviderName { get; }
    }
}