using Backend.Controllers.Services;
using Backend.Models;
using Backend.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Gets a list of events in DB
        /// </summary>
        /// <returns>A list of events</returns>
        [HttpGet("getAllEvents")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "List of Events", Description = "Lists of Events in DB")]
        [Authorize(Roles = "SuperAdmin,Admin,Manager,Participante")]
        public async Task<IActionResult> GetAllEvents()
        {
            bool existsE = _eventService.ExistsEvent();
            if (existsE)
            {
                List<AllEventsVM> list = await _eventService.GetsAllEvents();
                return Ok(list);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a Event as Admin.
        /// </summary>
        /// <returns></returns>
        [HttpPost("{adminId}/createEventAdmin")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Create Event", Description = "Create Event on DataBase")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEventAdmin([FromBody] CreateEventVM createEventVM, int adminId)
        {
            List<string> erros = _eventService.ValidateEvent(createEventVM.EventVM);

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                var eventId = await _eventService.AddEvent(createEventVM, adminId, null);
                List<PoapVM> poapVMs = createEventVM.PoapVMs;
                List<ImageVM> imageVMs = createEventVM.ImageVMs;

                foreach (PoapVM poapVM in poapVMs)
                {
                    await _eventService.AddImageToPoap(poapVM, eventId);
                }

                foreach (ImageVM imageVM in imageVMs)
                {
                    await _eventService.AddImage(imageVM, eventId);
                }

                foreach (int eventTypeId in createEventVM.EventTypesIds)
                {
                    await _eventService.AddEventType_Event(eventTypeId);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Changes Event Display.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpPut("{eventId}/changeEventDisplay")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Event display", Description = "Change Event display name on DataBase")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> EditEventDisplay(int eventId)
        {
            bool existsE = _eventService.ExistsEvent(eventId);

            if (existsE != true)
            {
                return BadRequest();
            }

            try
            {
                await _eventService.ChangeEventDisplay(eventId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Creates a Event as Manager.
        /// </summary>
        /// <returns></returns>
        [HttpPost("{managerId}/createEventManager")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Create Event", Description = "Create Event on DataBase")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateEventManager([FromBody] CreateEventVM createEventVM, int managerId)
        {
            List<string> erros = _eventService.ValidateEvent(createEventVM.EventVM);

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                var eventId = await _eventService.AddEvent(createEventVM, null, managerId);
                List<PoapVM> poapVMs = createEventVM.PoapVMs;
                List<ImageVM> imageVMs = createEventVM.ImageVMs;

                foreach (PoapVM poapVM in poapVMs)
                {
                    await _eventService.AddImageToPoap(poapVM, eventId);
                }

                foreach (ImageVM imageVM in imageVMs)
                {
                    await _eventService.AddImage(imageVM, eventId);
                }

                foreach (int eventTypeId in createEventVM.EventTypesIds)
                {
                    await _eventService.AddEventType_Event(eventTypeId);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Follow event.
        /// </summary>
        /// <param name="participanteId"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpPost("{participanteId}/{eventId}/follow")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Follow Event", Description = "Create an entry on DataBase to follow event")]
        [Authorize(Roles = "Participante")]
        public async Task<IActionResult> Follow(int participanteId, int eventId)
        {
            bool existsE = _eventService.ExistsEvent(eventId);

            if (existsE != true)
            {
                return BadRequest();
            }

            try
            {
                await _eventService.FollowEvent(participanteId, eventId);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok("Follow");
        }

        /// <summary>
        /// Unfollow event.
        /// </summary>
        /// <param name="participanteId"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpDelete("{participanteId}/{eventId}/unfollow")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Unfollow Event", Description = "Deletes an entry on DataBase to unfollow event")]
        [Authorize(Roles = "Participante")]
        public async Task<IActionResult> Unfollow(int participanteId, int eventId)
        {
            bool existsE = _eventService.ExistsEvent(eventId);

            if (existsE != true)
            {
                return BadRequest();
            }

            try
            {
                await _eventService.UnfollowEvent(participanteId, eventId);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok("Unfollows");
        }

        /// <summary>
        /// Gets Event Types
        /// </summary>
        /// <returns>A list of Event types</returns>
        [HttpGet("getEventTypes")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "Shows Event types", Description = "Shows Event types in DB")]
        [Authorize(Roles = "SuperAdmin,Admin,Manager")]
        public async Task<IActionResult> GetEventTypes()
        {
            bool existsET = _eventService.ExistsEventTypes();
            if (existsET)
            {
                var et = await _eventService.GetEventTypes();
                return Ok(et);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a Event Type.
        /// </summary>
        /// <returns></returns>
        [HttpPost("createEventType")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Create Event Type", Description = "Create Event Type on DataBase")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> CreateEventType([FromBody] String eventTypeName)
        {
            List<string> erros = _eventService.ValidateEventType(eventTypeName);

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                await _eventService.AddEventType(eventTypeName);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Changes Event Type name.
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="eventTypeId"></param>
        /// <returns></returns>
        [HttpPut("{eventTypeId}/changeEventTypeName")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Event Type name", Description = "Change Event Type name on DataBase")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> EditEventTypeName([FromBody] string newName, int eventTypeId)
        {
            List<string> erros = _eventService.ValidateEventType(newName);

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                await _eventService.EditEventTypeName(newName, eventTypeId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Remove Event Type
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{eventTypeId}/removeEventType")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "Remove Event Type", Description = "Removes an Event Type from the DB")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> RemoveEventType(int eventTypeId)
        {
            bool etExists = _eventService.ExistsEventTypes(eventTypeId);
            if (etExists)
            {
                try
                {
                    await _eventService.RemoveEventType(eventTypeId);
                    return Ok();
                }
                catch (System.Data.DataException e)
                {
                    return BadRequest(e.StackTrace);
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
