using Core.Domain.Entities;
using Wedding.Wishlist.Domain.Enums;

namespace Wedding.Wishlist.Domain.Entities
{
    public class Logs
        : EntityByGuid<Guid>
    {
        public LogType Type { get; set; } = LogType.Information;
        public Guid? RequestId { get; set; } = Guid.Empty;
        public string Message { get; set; } = string.Empty;
        public string? Trace { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? TargetId { get; set; } = string.Empty;
        public string? ReferenceType { get; set; }
        public string? ReferenceId { get; set; }
        public Guid? UsersId { get; set; }
    }
}
