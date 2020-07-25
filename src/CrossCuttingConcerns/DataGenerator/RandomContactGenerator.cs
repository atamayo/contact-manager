using System.Collections.Generic;
using Domain;
using FizzWare.NBuilder;

namespace CrossCuttingConcerns.DataGenerator
{
    internal class RandomContactGenerator
    {
        private readonly NameGenerator _nameGenerator;
        private readonly SurnameGenerator _surnameGenerator;

        public RandomContactGenerator()
        {
            BuilderSetup.DisablePropertyNamingFor<Contact, int>(x => x.Id);

            _nameGenerator = new NameGenerator();
            _surnameGenerator = new SurnameGenerator();
        }

        public IList<Contact> GenerateContacts(int size)
        {
            return Builder<Contact>
                .CreateListOfSize(size)
                .All()
                .WithFactory(FactorContacts)
                .Build();
        }

        private Contact FactorContacts()
        {
            var contact = new Contact
            {
                Name = _nameGenerator.Get(), 
                Surname = _surnameGenerator.Get(),
            };

            var generator = new RandomGenerator();

            contact.Email = $"{contact.Name}.{contact.Surname}@{generator.Enumeration<Emails>()}.com";
            
            var phone =  generator.Next(1111111111, 9999999999);

            

            contact.MobilePhone = $"{phone}";

            return contact;
        }

    }

    internal enum Emails   
    {
        Gmail,
        Outlook,
        iCloud,
        Aol,
        Yahoo,
        Microsoft,
        Apple
    }
}
