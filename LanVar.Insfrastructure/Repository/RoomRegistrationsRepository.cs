﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace LanVar.Infrastructure.Repository
{
    public class RoomRegistrationsRepository : IRoomRegistrationsRepository
    {
        private readonly MyDbContext _context;

        public RoomRegistrationsRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<RoomRegistrations> GetByIdAsync(long id)
        {
            return await _context.Set<RoomRegistrations>().FindAsync(id);
        }

        public async Task AddAsync(RoomRegistrations roomRegistrations)
        {
            await _context.Set<RoomRegistrations>().AddAsync(roomRegistrations);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RoomRegistrations roomRegistrations)
        {
            _context.Set<RoomRegistrations>().Update(roomRegistrations);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RoomRegistrations roomRegistrations)
        {
            _context.Set<RoomRegistrations>().Remove(roomRegistrations);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RoomRegistrations>> GetByAuctionIdAsync(long auctionId)
        {
            return await _context.Set<RoomRegistrations>()
                .Include(rr => rr.user)
                .Include(rr => rr.auction)
                .Where(rr => rr.auction_id == auctionId)
                .ToListAsync();
        }

        public async Task<List<RoomRegistrations>> GetByFilterAsync(Expression<Func<RoomRegistrations, bool>> filter)
        {
            return await _context.Set<RoomRegistrations>()
                .Where(filter)
                .ToListAsync();
        }
    }
}
