using EECommerceApp.DtoLayer.CatologDtos.ContactDtos;

namespace ECommerce.WebUı.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
