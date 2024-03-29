﻿using LanVar.Core.Entity;
using LanVar.Service.DTO;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LanVar.DTO.DTO.request;
using Tools.Tools;
using LanVar.DTO.request;
using LanVar.Service.DTO.request;
using LanVar.Services.Interface;

namespace LanDotBien_BackEnd.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Manage_Manager_Accounts : ControllerBase
    {
        private readonly IAccountService _accountService;

        public Manage_Manager_Accounts(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _accountService.GetAllUsers();
                if (users == null || !users.Any()) // Kiểm tra nếu không có người dùng nào được trả về
                {
                    return NotFound("Đéo Có Thằng Nào Hết"); // Báo trạng thái "Not Found" (404)
                }
                return Ok(users);
            }
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            try
            {
                var user = await _accountService.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateAccountDTORequest createAccountDTORequest)
        {
            try
            {
                User user = await _accountService.CreateUser(createAccountDTORequest);
                return Ok(createAccountDTORequest);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UpdateUserDTORequest updateUserDTORequest)
        {
            try
            {
                User user= await _accountService.UpdateUser(id, updateUserDTORequest);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("DeactivateUser/{id}")]
        public async Task<IActionResult> DeactivateUser(long id)
        {
            try
            {
                var result = await _accountService.DeactivateUser(id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok(new { message = "User deactivated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("ActivateUser/{id}")]
        public async Task<IActionResult> ActivateUser(long id)
        {
            try
            {
                var result = await _accountService.ActivateUser(id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok(new { message = "User activated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            try
            {
                var deletedUser = await _accountService.DeleteUser(id);
                if (deletedUser == null)
                {
                    return NotFound();
                }
                return Ok(new { message = "User deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
