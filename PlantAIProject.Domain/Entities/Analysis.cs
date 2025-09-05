// PlantAIProject.Domain/Entities/Analysis.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantAIProject.Domain.Entities
{
    public class Analysis
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string ObjectName { get; set; } = string.Empty;

        [Range(0.0, 1.0)]
        public double Confidence { get; set; }

        [Required]
        [MaxLength(50)]
        public string Provider { get; set; } = string.Empty; // "GoogleVision", "PlantId"

        public DateTime AnalysisDate { get; set; } = DateTime.UtcNow;

        // Additional plant-specific properties
        public string? CommonName { get; set; }
        public string? ScientificName { get; set; }
        public string? CareInstructions { get; set; }
        public string? Description { get; set; }

        // Foreign key
        [ForeignKey("Photo")]
        public int PhotoId { get; set; }

        // Navigation property
        public virtual Photo Photo { get; set; } = null!;
    }
}