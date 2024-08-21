using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _repository.GetByIdAsync(updateAddressCommand.AddressId);
            values.Detail1 = updateAddressCommand.Detail1;
            values.City = updateAddressCommand.City;
            values.District = updateAddressCommand.District;
            values.UserId = updateAddressCommand.UserId;
            values.Country = updateAddressCommand.Country;
            values.Email = updateAddressCommand.Email;
            values.City = updateAddressCommand.City;
            values.Surname = updateAddressCommand.Surname;
            values.Name = updateAddressCommand.Name;
            values.PhoneNumber = updateAddressCommand.PhoneNumber;
            values.Detail2 = updateAddressCommand.Detail2;
            values.ZipCode = updateAddressCommand.ZipCode;

            await _repository.UpdateAsync(values);
        }
    }
}
