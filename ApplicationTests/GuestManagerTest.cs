using Application.Guest;
using Application.Guest.DTO;
using Application.Guest.Requests;
using Application.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Moq;

namespace ApplicationTests
{
    public class Tests
    {
        GuestManager guestManager;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task HappyPath()
        {
            var guestDto = new GuestDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "Test@Gmail.com",
                IdNumber = "abcd",
                IdTypeCode = 1
            };

            int expectedId = 222;

            var request = new CreateGuestRequest
            {
                Data = guestDto,
            };
            var fakeRepo = new Mock<IGuestRepository>();

            fakeRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(expectedId));

            guestManager = new GuestManager(fakeRepo.Object);

            var result = await guestManager.CreateGuest(request);
            Assert.IsNotNull(result);
            Assert.True(result.Sucess);
            Assert.AreEqual(result.Data.Id, expectedId);
            Assert.AreEqual(result.Data.Name, guestDto.Name);
        }
        [Test]
        public async Task Shoud_Return_GuestNotFound_When_GuestDoesExist()
        {
            var fakeRepo = new Mock<IGuestRepository>();

            fakeRepo.Setup(x => x.Get(333)).Returns(Task.FromResult<Guest?>(null));

            guestManager = new GuestManager(fakeRepo.Object);

            var result = await guestManager.GetGuest(333);

            Assert.IsNotNull(result);
            Assert.False(result.Sucess);
            Assert.AreEqual(result.ErrorCodes, ErrorCodes.GUEST_NOT_FOUND);
            Assert.AreEqual(result.Message, "No Guest record was guest id");
        }
        [Test]
        public async Task Shoud_Return_GuestSucess()
        {
            var fakeRepo = new Mock<IGuestRepository>();

            var fakeGuest = new Guest()
            {
                Id = 333,
                Name = "Test",
                DocumentId = new Domain.ValueObjects.PersonId
                {
                    DocumentType = DocumentType.DriveLicence,
                    IdNumber = "123"
                }

            };

            fakeRepo.Setup(x => x.Get(333)).Returns(Task.FromResult((Guest?)fakeGuest));

            guestManager = new GuestManager(fakeRepo.Object);

            var result = await guestManager.GetGuest(333);

            Assert.IsNotNull(result);
            Assert.True(result.Sucess);
            Assert.AreEqual(result.Data.Id, fakeGuest.Id);
            Assert.AreEqual(result.Data.Name, fakeGuest.Name);
        }

        [TestCase(" ")]
        [TestCase("a")]
        [TestCase("ab")]
        [TestCase("abc")]
        public async Task Should_Return_InvalidPersonDocumentIdException_WhenDocsAreInvelid(string DocNumber)
        {
            var guestDto = new GuestDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "Test@Gmail.com",
                IdNumber = DocNumber,
                IdTypeCode = 1
            };

            var request = new CreateGuestRequest
            {
                Data = guestDto,
            };
            var fakeRepo = new Mock<IGuestRepository>();

            fakeRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(222));

            guestManager = new GuestManager(fakeRepo.Object);

            var result = await guestManager.CreateGuest(request);
            Assert.IsNotNull(result);
            Assert.False(result.Sucess);
            Assert.AreEqual(result.ErrorCodes, ErrorCodes.INVALID_PERSON_ID);
            Assert.AreEqual(result.Message, "The Id passed is not valid");
        }
        [TestCase("", "surname", "test@gmail.com")]
        [TestCase( "test", "", "test@gmail.com")]
        [TestCase( "test", "surname", "")]
        public async Task Should_Return_MissingRequiredInformation_WhenDocsAreInvelid(string name, string surname, string email)
        {
            var guestDto = new GuestDTO
            {
                Name = name,
                Surname = surname,
                Email = email,
                IdNumber = "abcd",
                IdTypeCode = 1
            };

            var request = new CreateGuestRequest
            {
                Data = guestDto,
            };
            var fakeRepo = new Mock<IGuestRepository>();

            fakeRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(222));

            guestManager = new GuestManager(fakeRepo.Object);

            var result = await guestManager.CreateGuest(request);
            Assert.IsNotNull(result);
            Assert.False(result.Sucess);
            Assert.AreEqual(result.ErrorCodes, ErrorCodes.MISSING_REQUIRED_INFORMATION);
            Assert.AreEqual(result.Message, "Missing required information passed");
        }
    }
}