using Backend.Common;
using Backend.Models;
using Backend.Models.VM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace Backend.Controllers.Services
{
    public class EventService
    {
        private readonly AppDbContext _context;
        private readonly EntityService _entity;
        public EventService(AppDbContext context, EntityService entity)
        {
            _context = context;
            _entity = entity;
        }

        /// <summary>
        /// Create an Event type in db
        /// </summary>
        /// <param name="eventType">Event type that want to create in db</param>
        public async Task AddEventType(String eventType)
        {
            var _eve = new EventType(eventType);
            _context.EventTypes.Add(_eve);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes an Event type from the db
        /// </summary>
        /// <param name="eventTypeId">Id of the Event Type that is to remove"</param>
        public async Task RemoveEventType(int eventTypeId)
        {
            var eve = await _context.EventTypes.FindAsync(eventTypeId);
            if (eve != null)
            {
                _context.EventTypes.Remove(eve);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets Event Type list
        /// </summary>
        /// <returns>Return list of Event Type</returns>
        public async Task<List<EventTypeVM>> GetEventTypes()
        {
            if (ExistsEventTypes())
            {
                List<EventTypeVM> list = new();
                var eves = await _context.EventTypes.ToListAsync();

                foreach (var eve in eves)
                {
                    EventTypeVM eventTypeVm = new(eve.Id,eve.Type);
                    list.Add(eventTypeVm);
                }
                return list;
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Edit Event Type name
        /// </summary>
        /// <param name="newName">New name for the admin</param>
        /// <param name="eventTypeId">Id of the Event Type to change name</param>
        public async Task EditEventTypeName(string newName, int eventTypeId)
        {
            var eve = await _context.EventTypes.FindAsync(eventTypeId);
            if (eve != null)
            {
                eve.Type = newName;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Verify if exists any Event Type
        /// </summary>
        /// <returns>Return bool, true if exists or false if it doesn't</returns>
        public bool ExistsEventTypes()
        {
            return _context.EventTypes.Any();
        }

        /// <summary>
        /// Verify if exists any Event Type
        /// </summary>
        /// <param name="eventTypeName">Name of Event type to verify if exists</param>
        /// <returns>Return bool, true if exists or false if it doesn't</returns>
        public bool ExistsEventTypes(string eventTypeName)
        {
            return _context.EventTypes.Any(e => e.Type.Equals(eventTypeName));
        }

        /// <summary>
        /// Verify if exists any Event Type
        /// </summary>
        /// <param name="eventTypeId">Id of Event type to verify if exists</param>
        /// <returns>Return bool, true if exists or false if it doesn't</returns>
        public bool ExistsEventTypes(int eventTypeId)
        {
            return  _context.EventTypes.Any(e=>e.Id == eventTypeId);
        }

        /// <summary>
        /// Verify if exists any Event Type
        /// </summary>
        /// <param name="eventId">Id of Event to verify if exists</param>
        /// <returns>Return bool, true if exists or false if it doesn't</returns>
        public bool ExistsEvent(int eventId)
        {
            return _context.Events.Any(e => e.Id == eventId);
        }

        /// <summary>
        /// Verify if exists any Event Type
        /// </summary>
        /// <returns>Return bool, true if exists or false if it doesn't</returns>
        public bool ExistsEvent()
        {
            return _context.Events.Any();
        }

        /// <summary>
        /// Verify if Event Type is valid
        /// </summary>
        /// <param name="EventTypeName">Name of Event Type to validate</param>
        /// <returns>A list with errors, or an empty list if there aren't any errors</returns>
        public List<string> ValidateEventType(string EventTypeName)
        {
            List<string> errors = new();

            if (EventTypeName.Trim().Equals(""))
            {
                errors.Add("Invalid Entity Name");
            }
            else if (ExistsEventTypes(EventTypeName))
            {
                errors.Add("Entity with this name already exists");
            }

            return new List<string>(errors);
        }

        /// <summary>
        /// Verify if Event Type is valid
        /// </summary>
        /// <param name="eventVM">Event to validate</param>
        /// <returns>A list with errors, or an empty list if there aren't any errors</returns>
        public List<string> ValidateEvent(EventVM eventVM)
        {
            List<string> errors = new();

            if (eventVM.Name.Trim().Equals(""))
            {
                errors.Add("Invalid Event Name");
            }

            return new List<string>(errors);
        }

        /// <summary>
        /// Create an Event in db
        /// </summary>
        /// <param name="createEventVM">Event info that want to create in db</param>
        /// <param name="adminId">Id of the Admin creating event</param>
        /// <param name="managerId">Id of the Manager creating event</param>
        /// <returns>Id of the event or 0 if failed</returns>
        public async Task<int> AddEvent(CreateEventVM createEventVM, int? adminId, int? managerId)
        {
            if (adminId != null)
            {
                var user = await _context.Admins.FindAsync(adminId);
                if (user != null)
                {
                    var eve = new Event(false, createEventVM.EventVM.Name, user.Name, createEventVM.EventVM.Lat, createEventVM.EventVM.Long, createEventVM.EventVM.Time, 
                        createEventVM.EventVM.Description, createEventVM.EventVM.Registed, createEventVM.EventVM.Max, true, _entity.GetEntityId(), adminId, null);
                    _context.Events.Add(eve);

                    await _context.SaveChangesAsync();
                }

                var eventCreated = await _context.Events.SingleOrDefaultAsync(u => u.Description.Equals(createEventVM.EventVM.Description)
                && u.AdminId.Equals(adminId) && u.Time.Equals(createEventVM.EventVM.Time) && u.Name.Equals(createEventVM.EventVM.Name));

                if (eventCreated != null)
                {
                    return eventCreated.Id;
                }
            }
            if (managerId != null)
            {
                var user = await _context.Managers.FindAsync(managerId);
                if (user != null && user.Display == true)
                {
                    var eve = new Event(true, createEventVM.EventVM.Name, user.Name, createEventVM.EventVM.Lat, createEventVM.EventVM.Long, createEventVM.EventVM.Time,
                        createEventVM.EventVM.Description, createEventVM.EventVM.Registed, createEventVM.EventVM.Max, true, _entity.GetEntityId(), null, managerId);
                    _context.Events.Add(eve);

                    await _context.SaveChangesAsync();

                    var eventCreated = await _context.Events.SingleOrDefaultAsync(u => u.Description.Equals(createEventVM.EventVM.Description)
                    && u.ManagerId.Equals(managerId) && u.Time.Equals(createEventVM.EventVM.Time) && u.Name.Equals(createEventVM.EventVM.Name));

                    if (eventCreated != null)
                    {
                        return eventCreated.Id;
                    }
                }
            }
            throw new Exception("Failed add event");
        }

        /// <summary>
        /// Create a Poap with image info in db
        /// </summary>
        /// <param name="poapVM">Poap that want to create in db</param>
        /// <param name="eventId">Id of the event</param>
        public async Task AddImageToPoap(PoapVM poapVM, int eventId)
        {
            var ima = new Image(poapVM.ImageVM.FileName, poapVM.ImageVM.ImageData, eventId);
            _context.Images.Add(ima);

            await _context.SaveChangesAsync();

            var imageCreated = await _context.Images.SingleOrDefaultAsync(u => u.FileName.Equals(poapVM.ImageVM.FileName)
            && u.ImageData.Equals(poapVM.ImageVM.ImageData));

            if (imageCreated != null)
            {
                Poap poap = new(poapVM.Name, poapVM.PoapFancyId, eventId, imageCreated.Id);
                _context.Poaps.Add(poap);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Create a Relation between EventType and Event in db
        /// </summary>
        /// <param name="eventTypeId">Id of the event type</param>
        public async Task AddEventType_Event(int eventTypeId)
        {
            var eventType_event = new EventType_Event(eventTypeId, _entity.GetEntityId());
            _context.EventType_Events.Add(eventType_event);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Create an Image in db
        /// </summary>
        /// <param name="imageVM">Image that want to create in db</param>
        /// <param name="eventId">Id of the event</param>
        public async Task AddImage(ImageVM imageVM, int eventId)
        {
            var ima = new Image(imageVM.FileName, imageVM.ImageData, eventId);
            _context.Images.Add(ima);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifies if Participante follows event in db
        /// </summary>
        /// <param name="participanteId">Id of the participante</param>
        /// <param name="eventId">Id of the event</param>
        public bool ParticipanteFollowsEvent(int participanteId, int eventId)
        {
            var follows = _context.Participante_Events.SingleOrDefault(e=>e.ParticipanteId.Equals(participanteId) && e.EventId.Equals(eventId));
            if (follows != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Create an entry Participante_Event in db to follow
        /// </summary>
        /// <param name="participanteId">Id of the participante</param>
        /// <param name="eventId">Id of the event</param>
        public async Task FollowEvent(int participanteId, int eventId)
        {
            var follows = ParticipanteFollowsEvent(participanteId, eventId);
            if (follows == false)
            {
                var partEve = new Participante_Event(participanteId, eventId);
                _context.Participante_Events.Add(partEve);

                await _context.SaveChangesAsync();
            }
            throw new Exception();
        }

        /// <summary>
        /// Delete an entry Participante_Event in db to unfollow
        /// </summary>
        /// <param name="participanteId">Id of the participante</param>
        /// <param name="eventId">Id of the event</param>
        public async Task UnfollowEvent(int participanteId, int eventId)
        {
            var follows = ParticipanteFollowsEvent(participanteId, eventId);
            if (follows == true)
            {
                var partEve = _context.Participante_Events.SingleOrDefault(e => e.ParticipanteId.Equals(participanteId) && e.EventId.Equals(eventId));
                if(partEve != null)
                {
                    _context.Participante_Events.Remove(partEve);

                    await _context.SaveChangesAsync();
                }
            }
            throw new Exception();
        }

        /// <summary>
        /// Delete an entry Participante_Event in db to unfollow
        /// </summary>
        /// <param name="eventId">Id of the event</param>
        public async Task ChangeEventDisplay(int eventId)
        {
            var eventd = await _context.Events.FindAsync(eventId);
            if (eventd != null)
            {
                if(eventd.Display == true)
                {
                    eventd.Display = false;
                    await _context.SaveChangesAsync();
                } 
                else
                {
                    eventd.Display = true;
                    await _context.SaveChangesAsync();
                }
            }
            throw new Exception();
        }

        /// <summary>
        /// Gets a list of events
        /// </summary>
        /// <returns>Return list of Events</returns>
        public async Task<List<AllEventsVM>> GetsAllEvents()
        {
            if (ExistsEvent())
            {
                List<AllEventsVM> listEvents = new();
                List<ImageVM> images = new();
                var even = await _context.Events.ToListAsync();
                var imagesDB = await _context.Images.ToListAsync();

                foreach(var eve in even)
                {
                    if(eve.Display == true)
                    {
                        EventVMv2 eventVMv2 = new(eve.Name,eve.Lat,eve.Long,eve.Time,eve.Description,eve.Registed,eve.Max);

                        foreach(var image in imagesDB)
                        {
                            if(image.EventId == eve.Id)
                            {
                                ImageVM im = new(image.FileName, image.ImageData);
                                images.Add(im);
                            }
                        }

                        AllEventsVM allEve = new(eventVMv2, images);
                        listEvents.Add(allEve);
                    }
                }
                return listEvents;
            }
            throw new Exception("Empty database table");
        }
    }
}
