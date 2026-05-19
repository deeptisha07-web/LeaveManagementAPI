using LeaveManagementAPI.DTOs;
using LeaveManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LeaveManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LeaveController : ControllerBase
    {
        private readonly LeaveService _leaveService;

        public LeaveController(LeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpPost("apply")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Apply(LeaveRequestDTO dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _leaveService.ApplyLeave(userId, dto);
            return Ok(result);
        }

        [HttpGet("my-leaves")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> MyLeaves()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var leaves = await _leaveService.GetMyLeaves(userId);
            return Ok(leaves);
        }

        [HttpGet("all-leaves")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllLeaves()
        {
            var leaves = await _leaveService.GetAllLeaves();
            return Ok(leaves);
        }

        [HttpPut("update-status/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, LeaveStatusDTO dto)
        {
            var result = await _leaveService.UpdateStatus(id, dto);
            return Ok(result);
        }
    }
}