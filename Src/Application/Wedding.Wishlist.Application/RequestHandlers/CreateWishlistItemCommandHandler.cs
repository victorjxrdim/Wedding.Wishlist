using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.RequestHandlers;
using Core.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Entities;
using Wedding.Wishlist.Domain.Enums;
using Wedding.Wishlist.Domain.Interfaces;

namespace Wedding.Wishlist.Application.RequestHandlers
{
    internal class CreateWishlistItemCommandHandler(
        ILogger<CreateWishlistItemCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IServiceProvider serviceProvider,
        ICurrentUser currentUser)     
        : BaseRequestHandler<CreateWishlistItemCommand, CreateWishlistItemCommandResult>(logger, mapper, unitOfWork, serviceProvider, currentUser)
    {        
        public override async Task<CreateWishlistItemCommandResult?> Execute(CreateWishlistItemCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                return BadRequest(command.GetValidationResult());
            }

            try
            {
                var logService = _serviceProvider.GetRequiredService<ILogService>();
                var wishlistRepository = _unitOfWork.Repository<Wishlists, Guid>();                
                var wishlistDto = command.ToDto();

                var createNewWishlist = _mapper.Map<Wishlists>(wishlistDto);
                createNewWishlist.IsActive = 1;

                var wishlistItem = await wishlistRepository.CreateAsync(createNewWishlist, cancellationToken);

                logService.CreateLog(LogType.Information, "New wishlist item created.", referenceType: "WISHLISTS", referenceId: wishlistItem!.Id.ToString(), usersId: _currentUser!.UserId);

                await _unitOfWork.CommitAsync(cancellationToken);

                return Ok(new CreateWishlistItemCommandResult());
            }
            catch (Exception ex) 
            {
                return InternalServerError($"Erro {ex}");
            }            
        }
    }
}
