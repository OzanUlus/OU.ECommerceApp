using ECommerceApp.DtoLayer.CommentDtos;

namespace ECommerce.WebUı.Services.CommentServices
{
    public interface ICommentService
    {

        Task<List<ResultCommentDto>> GetAllAsync();
        Task<List<ResultCommentDto>> CommentListByProductId(string id);
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);
        Task<UpdateCommentDto> GetByIdCommentAsync(string id);
    }
}
