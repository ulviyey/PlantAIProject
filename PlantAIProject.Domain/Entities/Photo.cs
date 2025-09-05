// PlantAIProject.Domain/Entities/Photo.cs
using System.ComponentModel.DataAnnotations;

namespace PlantAIProject.Domain.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        public byte[] ImageData { get; set; } = Array.Empty<byte>();

        public DateTime UploadDate { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        public string ContentType { get; set; } = string.Empty;

        public long FileSizeBytes { get; set; }

        // Navigation property
        public virtual ICollection<Analysis> Analyses { get; set; } = new List<Analysis>();
    }
}