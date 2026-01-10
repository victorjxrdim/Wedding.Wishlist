using Wedding.Wishlist.Domain.Enums;

namespace Wedding.Wishlist.Domain.Interfaces
{
    public interface ILogService
    {
        void CreateLog(
            LogType logType,
            string message,
            Guid? requestId = null,            
            string? trace = null,
            string? targetId = null,
            string? referenceType = null,
            string? referenceId = null,
            Guid? usersId = null);
    }
}
