using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Moq;
using NUnit.Framework;
using Services.ContactManager;

namespace Services.Tests.ContactManager
{
    
    [TestFixture]
    class ContactCreationServiceTests
    {
        private IContactCreationService _contactCreationService;
        private Mock<IContactRepository> _contactRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _contactRepositoryMock = new Mock<IContactRepository>();
            _contactCreationService = new ContactCreationService(_contactRepositoryMock.Object);
        }

        [Test]
        public void ContactCreationService_Contact_AddNewAsync()
        {
            _contactCreationService.AddNewAsync(new Contact());
            _contactRepositoryMock.Verify( r => r.AddAsync(It.IsAny<Contact>()), Times.Once);
        }

        [Test]
        public void ContactCreationService_Contact_EditAsync()
        {
            _contactCreationService.EditAsync(new Contact());
            _contactRepositoryMock.Verify(r => r.EditAsync(It.IsAny<Contact>()), Times.Once);
        }

        [Test]
        public void ContactCreationService_Contact_DeleteAsync()
        {
            _contactCreationService.DeleteAsync(0);
            _contactRepositoryMock.Verify(r => r.DeleteAsync(0), Times.Once);
        }

    }
}
