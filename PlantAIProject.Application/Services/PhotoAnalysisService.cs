// PlantAIProject.Application/Services/PhotoAnalysisService.cs
using PlantAIProject.Application.Interfaces;
using PlantAIProject.Domain.Entities;
using PlantAIProject.Domain.ValueObjects;

namespace PlantAIProject.Application.Services
{
    public class PhotoAnalysisService
    {
        private readonly IAIAnalysisService _aiService;
        private readonly IPhotoRepository _photoRepository;

        public PhotoAnalysisService(IAIAnalysisService aiService, IPhotoRepository photoRepository)
        {
            _aiService = aiService;
            _photoRepository = photoRepository;
        }

        public async Task<AnalysisResult> AnalyzePhotoAsync(byte[] imageData, string fileName, string contentType)
        {
            // Validate image
            if (imageData == null || imageData.Length == 0)
                throw new ArgumentException("Image data cannot be empty");

            if (imageData.Length > 5 * 1024 * 1024) // 5MB limit
                throw new ArgumentException("Image size cannot exceed 5MB");

            // Analyze with AI service
            var analysisResult = await _aiService.AnalyzeImageAsync(imageData, fileName);

            // Create photo entity
            var photo = new Photo
            {
                FileName = fileName,
                ImageData = imageData,
                ContentType = contentType,
                FileSizeBytes = imageData.Length,
                UploadDate = DateTime.UtcNow
            };

            // Create analysis entity
            var analysis = new Analysis
            {
                ObjectName = analysisResult.ObjectName,
                Confidence = analysisResult.Confidence,
                Provider = analysisResult.Provider,
                CommonName = analysisResult.CommonName,
                ScientificName = analysisResult.ScientificName,
                CareInstructions = analysisResult.CareInstructions,
                Description = analysisResult.Description,
                AnalysisDate = DateTime.UtcNow
            };

            photo.Analyses.Add(analysis);

            // Save to database (Aşama 3'te aktif olacak)
            // await _photoRepository.AddAsync(photo);

            return analysisResult;
        }

        public async Task<IEnumerable<Photo>> GetRecentPhotosAsync(int count = 10)
        {
            return await _photoRepository.GetRecentAsync(count);
        }

        public async Task<Photo?> GetPhotoByIdAsync(int id)
        {
            return await _photoRepository.GetByIdAsync(id);
        }
    }
}