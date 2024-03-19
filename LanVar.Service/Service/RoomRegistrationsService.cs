﻿using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Tools;

namespace LanVar.Service.Service
{
    public class RoomRegistrationsService : IRoomRegistrationsService
    {
        private readonly IRoomRegistrationsRepository _roomRegistrationsRepository;
        private readonly IMapper _mapper;

        public RoomRegistrationsService(IRoomRegistrationsRepository roomRegistrationsRepository, IMapper mapper)
        {
            _roomRegistrationsRepository = roomRegistrationsRepository;
            _mapper = mapper;
        }

        public async Task<RoomRegistrationsDTOResponse> GetByIdAsync(long id)
        {
            var roomRegistrations = await _roomRegistrationsRepository.GetByAuctionIdAsync(id);

            return _mapper.Map<RoomRegistrationsDTOResponse>(roomRegistrations);
        }

        public async Task<RoomRegistrationsDTOResponse> CreateAsync(RoomRegistrationsDTORequest roomRegistrationsDTO)
        {
            var roomRegistrations = _mapper.Map<RoomRegistrations>(roomRegistrationsDTO);
            roomRegistrations.register_time = DateTime.Now; // Assuming register time should be set upon creation
            await _roomRegistrationsRepository.AddAsync(roomRegistrations);
            return _mapper.Map<RoomRegistrationsDTOResponse>(roomRegistrations);
        }

        public async Task<RoomRegistrationsDTOResponse> UpdateAsync(long id, RoomRegistrationsDTORequest roomRegistrationsDTO)
        {
            var existingRoomRegistrations = await _roomRegistrationsRepository.GetByIdAsync(id);
            if (existingRoomRegistrations == null)
            {
                throw new Exception("RoomRegistrations not found");
            }

            _mapper.Map(roomRegistrationsDTO, existingRoomRegistrations);
            await _roomRegistrationsRepository.UpdateAsync(existingRoomRegistrations);
            return _mapper.Map<RoomRegistrationsDTOResponse>(existingRoomRegistrations);
        }

        public async Task<List<RoomRegistrationsDTOResponse>> GetByAuctionIdAsync(long auctionId)
        {
            var roomRegistrationsList = await _roomRegistrationsRepository.GetByAuctionIdAsync(auctionId);
            return _mapper.Map<List<RoomRegistrationsDTOResponse>>(roomRegistrationsList);
        }

        public async Task<RoomRegistrationsDTOResponse> AcceptUser(long roomRegistrationId)
        {
            var roomRegistration = await _roomRegistrationsRepository.GetByIdAsync(roomRegistrationId);
            if (roomRegistration == null)
            {
                throw new Exception("RoomRegistrations not found");
            }

            // Perform your logic to accept the user here.
            // For example, you may change the status of the room registration to "ACTIVE".
            roomRegistration.status = RegisterStatus.ACTIVE;

            // Save the changes to the database.
            await _roomRegistrationsRepository.UpdateAsync(roomRegistration);

            // Map the updated room registration to DTO response and return it.
            return _mapper.Map<RoomRegistrationsDTOResponse>(roomRegistration);
        }

        public async Task DeleteAsync(long id)
        {
            var existingRoomRegistrations = await _roomRegistrationsRepository.GetByIdAsync(id);
            if (existingRoomRegistrations == null)
            {
                throw new Exception("RoomRegistrations not found");
            }

            await _roomRegistrationsRepository.DeleteAsync(existingRoomRegistrations);
        }
    }
}
