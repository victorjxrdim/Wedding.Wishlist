using AutoMapper;
using Core.Application.RequestHandlers;
using Core.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.Application.Responses;

namespace Wedding.Wishlist.Application.RequestHandlers
{
    internal class CreateWishlistItemCommandHandler(
        ILogger<CreateWishlistItemCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork)     
        : BaseRequestHandler<CreateWishlistItemCommand, CreateWishlistItemResult>(logger, mapper, unitOfWork)
    {        
        public override async Task<CreateWishlistItemResult?> Execute(CreateWishlistItemCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                return BadRequest(command.GetValidationResult());
            }
            try
            {

            }
            catch (Exception ex) 
            { 

            }

            return Ok(new CreateWishlistItemResult());
        }
    }
}
