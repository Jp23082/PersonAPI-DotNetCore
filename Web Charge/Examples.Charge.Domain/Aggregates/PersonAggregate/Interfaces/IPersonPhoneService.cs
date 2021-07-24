using Examples.Charge.Domain.ViewModels;
using System.Collections.Generic;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        List<PersonPhoneViewModel> Get();
        bool Post(PersonPhoneViewModel personPhoneViewModel);
        PersonPhoneViewModel GetByBusinessEntityID(string id);
        bool Put(PersonPhoneViewModel personPhoneViewModel);
        bool Delete(string id);
    }
}
