using AutoMapper;
using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Wishlist.Domain.Entities;
using Wedding.Wishlist.Domain.Enums;
using Wedding.Wishlist.Domain.Interfaces;

namespace Wedding.Wishlist.Application.Services
{
    public class LogService(
        IMapper mapper,
        IUnitOfWork unitOfWork) 
        : ILogService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async void CreateLog(
            LogType logType, 
            string message, 
            Guid? requestId = null, 
            string? trace = null, 
            string? targetId = null, 
            string? referenceType = null, 
            string? referenceId = null, 
            Guid? usersId = null)
        {
            var logRepository = _unitOfWork.Repository<Logs, Guid>();

            await logRepository.CreateAsync(new Logs
            {
                Type = logType,
                Message = message,
                RequestId = requestId,
                Trace = trace,
                TargetId = targetId,
                ReferenceType = referenceType,
                ReferenceId = referenceId,
                UsersId = usersId,
                CreatedAt = DateTime.UtcNow
            });

            return;
        }
    }
}
