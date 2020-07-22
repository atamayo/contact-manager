using System;
using System.Collections.Generic;

namespace Domain.Contact
{
    public interface IContactRepository
    {
       IContact GetById(Guid id);
       void Save(IContact contact);
       ICollection<IContact> GetAll();
    }
}