namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SongPerformer
    {
        public int SongId { get; set; }
        [Required]
        public virtual Song Song { get; set; }

        public int PerformerId { get; set; }
        [Required]
        public virtual Performer Performer { get; set; }
    }
}