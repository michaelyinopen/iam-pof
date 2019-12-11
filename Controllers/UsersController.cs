using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using IamPof.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IamPof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        public UsersController(
            IamPofDbContext iamPofDbContext,
            IMapper mapper)
        {
            IamPofDbContext = iamPofDbContext;
            Mapper = mapper;
        }

        private IamPofDbContext IamPofDbContext { get; }
        private IMapper Mapper { get; }

        // note remember to urlEncode the "sub" in url
        [HttpPut("{sub}", Name = "CreateOrUpdateUser")]
        //[Authorize("create-or-update:user")]
        [Authorize()]
        public async Task<ActionResult<UpdatedUserDto>> CreateOrUpdateUserAsync(string sub, [FromBody]CreateOrUpdateUserDto createOrUpdateUserDto)
        {
            if (!string.Equals(sub, createOrUpdateUserDto.Sub))
            {
                return BadRequest("Url does not match body.");
            }

            var user = Mapper.Map<User>(createOrUpdateUserDto);
            var current = await IamPofDbContext.User.FirstOrDefaultAsync(u => u.Sub == sub);
            UpdatedUserDto updatedUserDto;
            if (current is null)
            {   // create
                IamPofDbContext.User.Add(user);
                await IamPofDbContext.SaveChangesAsync();
                updatedUserDto = Mapper.Map<UpdatedUserDto>(user);
            }
            else
            {   // update
                user.Id = current.Id;
                IamPofDbContext.Entry(current).CurrentValues.SetValues(user);
                await IamPofDbContext.SaveChangesAsync();
                updatedUserDto = Mapper.Map<UpdatedUserDto>(user);
            }
            return Ok(updatedUserDto);
        }
    }
}