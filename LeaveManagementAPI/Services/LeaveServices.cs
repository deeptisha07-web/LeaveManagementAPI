using LeaveManagementAPI.Data;
using LeaveManagementAPI.DTOs;
using LeaveManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementAPI.Services
{
    public class LeaveService
    {
        private readonly AppDbContext _context;

        public LeaveService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> ApplyLeave(int userId, LeaveRequestDTO dto)
        {
            var leave = new LeaveRequest
            {
                UserId = userId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason,
                Status = "Pending",
                AppliedOn = DateTime.UtcNow
            };

            _context.LeaveRequests.Add(leave);
            await _context.SaveChangesAsync();
            return "Leave applied successfully";
        }

        public async Task<List<LeaveRequest>> GetMyLeaves(int userId)
        {
            return await _context.LeaveRequests
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetAllLeaves()
        {
            return await _context.LeaveRequests
                .Include(l => l.User)
                .ToListAsync();
        }

        public async Task<string> UpdateStatus(int leaveId, LeaveStatusDTO dto)
        {
            var leave = await _context.LeaveRequests.FindAsync(leaveId);

            if (leave == null)
                return "Leave request not found";

            leave.Status = dto.Status;
            await _context.SaveChangesAsync();
            return $"Leave {dto.Status} successfully";
        }
    }
}