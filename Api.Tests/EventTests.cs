using NUnit.Framework;
using Moq;
using Api.Services.Contracts;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Tests
{
    public class EventServiceTests
    {
        private Mock<IEventService> _eventServiceMock;

        [SetUp]
        public void Setup()
        {
            _eventServiceMock = new Mock<IEventService>();
        }

        [Test]
        public async Task TestCreateEventAsync()
        {
            var eventItem = new Event { 
                Id = Guid.NewGuid(), 
                Title = "Test Event", 
                Description = "This is a test event", 
                Date = DateTime.Now, 
                Location = "Test Location"
            };
            
            _eventServiceMock.Setup(x => x.CreateEventAsync(eventItem)).Returns(Task.CompletedTask);

            await _eventServiceMock.Object.CreateEventAsync(eventItem);

            _eventServiceMock.Verify(x => x.CreateEventAsync(eventItem), Times.Once);
        }

        [Test]
        public async Task TestDeleteEventAsync()
        {
            var id = "testId";
            _eventServiceMock.Setup(x => x.DeleteEventAsync(id)).Returns(Task.CompletedTask);

            await _eventServiceMock.Object.DeleteEventAsync(id);

            _eventServiceMock.Verify(x => x.DeleteEventAsync(id), Times.Once);
        }

        [Test]
        public async Task TestGetEventsAsync()
        {
            var events = new List<Event> 
            {
                new Event 
                { 
                    Id = Guid.NewGuid(), 
                    Title = "Test Event 1", 
                    Description = "This is a test event 1", 
                    Date = DateTime.Now, 
                    Location = "Test Location 1" 
                },
                new Event 
                { 
                    Id = Guid.NewGuid(), 
                    Title = "Test Event 2", 
                    Description = "This is a test event 2", 
                    Date = DateTime.Now, 
                    Location = "Test Location 2" 
                }
            };
            
            _eventServiceMock.Setup(x => x.GetEventsAsync()).ReturnsAsync(events);

            var result = await _eventServiceMock.Object.GetEventsAsync();

            Assert.AreEqual(events, result);
            _eventServiceMock.Verify(x => x.GetEventsAsync(), Times.Once);
        }

        [Test]
        public async Task TestUpdateEventAsync()
        {
            var eventItem = new Event 
            { 
                Id = Guid.NewGuid(), 
                Title = "Test Event", 
                Description = "This is a test event", 
                Date = DateTime.Now, 
                Location = "Test Location" 
            };
            
            _eventServiceMock.Setup(x => x.UpdateEventAsync(eventItem)).Returns(Task.CompletedTask);

            await _eventServiceMock.Object.UpdateEventAsync(eventItem);

            _eventServiceMock.Verify(x => x.UpdateEventAsync(eventItem), Times.Once);
        }
    }
}