using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IContactRepository
    {
       Contact GetById(int id);
       void Save(Contact contact);
       ICollection<Contact> GetAll();
    }
}