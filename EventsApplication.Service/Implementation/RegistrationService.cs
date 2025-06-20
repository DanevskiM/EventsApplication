﻿using CoursesApplication.Repository.Interface;
using EventsApplication.Domain.DomainModels;
using EventsApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventsApplication.Service.Implementation
{
    public class RegistrationService : IRegisrationService
    {
        private readonly IRepository<Registration> _registrationRepository;
        private readonly IAttendeeService _attendeeService;
        private readonly IEventService _eventService;
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IRepository<EventInSchedule> _eventsInScheduleRepository;

        public RegistrationService(IRepository<Registration> registrationRepository, IAttendeeService attendeeService, IEventService eventService, IRepository<Schedule> scheduleRepository, IRepository<EventInSchedule> eventInScheduleRepository)
        {
            _registrationRepository = registrationRepository;
            _attendeeService = attendeeService;
            _eventService = eventService;
            _scheduleRepository = scheduleRepository;
            _eventsInScheduleRepository = eventInScheduleRepository;
        }

        public List<Registration> GetAll()
        {
            return _registrationRepository
                .GetAll(
                    selector: x => x,
                    include: x => x.Include(z => z.Event).Include(z => z.Owner).Include(z => z.Attendee)
                ).ToList();
        }
        public List<Registration> GetAllByCurrentUser(string userId)
        {
            return _registrationRepository
                .GetAll(
                    selector: x => x,
                    predicate: x => x.OwnerId.Equals(userId),
                    include: x => x.Include(z => z.Event).Include(z => z.Owner).Include(z => z.Attendee)
                ).ToList();
        }

        public Registration? GetById(Guid id)
        {
            return _registrationRepository
                .Get(
                    selector: x => x,
                    predicate: x => x.Id.Equals(id),
                    include: x => x.Include(z => z.Event).Include(z => z.Owner).Include(z => z.Attendee)
                );
        }

        public Registration DeleteById(Guid id)
        {
            var registration = GetById(id);
            if (registration == null)
            {
                throw new Exception("Registration not found");
            }
            return _registrationRepository.Delete(registration);
        }

        public Registration RegisterAttendeeOnEvent(string userId, Guid attendeeId, Guid eventId, string paymentStatus)
        {
            var attendee = _attendeeService.GetById(attendeeId);
            var @event = _eventService.GetById(eventId);
            if (attendee == null || @event == null)
            {
                throw new Exception("Attendee or Event not found");
            }

            var registration = new Registration
            {
                Id = Guid.NewGuid(),
                OwnerId = userId,
                AttendeeId = attendeeId,
                EventId = eventId,
                PaymentStatus = paymentStatus
            };
            return _registrationRepository.Insert(registration);
        }

        public Schedule CreateSchedule(string userId)
        {
            var userRegistration = _registrationRepository
                .GetAll(
                    selector: x => x,
                    predicate: x => x.OwnerId == userId
                ).ToList();
            if (!userRegistration.Any())
                return null;
            var newSchedule = new Schedule
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                EventInSchedules = new List<EventInSchedule>()
            };
            _scheduleRepository.Insert(newSchedule);
            foreach(var registration in userRegistration)
            {
                var eventInSchedule = new EventInSchedule
                {
                    Id=Guid.NewGuid(),
                    EventId=registration.Id,
                    ScheduleId=newSchedule.Id,
                    Quantity=1
                };
                _eventsInScheduleRepository.Insert(eventInSchedule);
                newSchedule.EventInSchedules.Add(eventInSchedule);
            }
            foreach (var r in userRegistration)
            {
                _registrationRepository.Delete(r);
            }
            return newSchedule;
        }
    }
}