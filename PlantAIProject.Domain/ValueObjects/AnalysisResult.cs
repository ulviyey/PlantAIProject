// PlantAIProject.Domain/ValueObjects/AnalysisResult.cs
namespace PlantAIProject.Domain.ValueObjects
{
    public record AnalysisResult
    {
        public string ObjectName { get; init; } = string.Empty;
        public double Confidence { get; init; }
        public string Provider { get; init; } = string.Empty;
        public string? CommonName { get; init; }
        public string? ScientificName { get; init; }
        public string? CareInstructions { get; init; }
        public string? Description { get; init; }
        public Dictionary<string, object> RawData { get; init; } = new();
    }
}