using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using IamPof.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IamPof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(
            IamPofDbContext iamPofDbContext,
            IMapper mapper)
        {
            IamPofDbContext = iamPofDbContext;
            Mapper = mapper;
        }

        private IamPofDbContext IamPofDbContext { get; }
        private IMapper Mapper { get; }

        [HttpPut(Name = "CreateOrUpdateUser")]
        public async Task<IActionResult> CreateOrUpdateUserAsync([FromBody]CreateOrUpdateUserDto createOrUpdateUserDto)
        {
            string sub = User.FindFirst("sub")?.Value;
            if (!string.Equals(sub, createOrUpdateUserDto.Sub))
            {
                return BadRequest("Sub Claim does not match body.");
            }

            var user = Mapper.Map<User>(createOrUpdateUserDto);
            UpdatedUserDto updatedUserDto;
            //if (createOrUpdateUserDto.Id is null)
            //{   // create
            //    IamPofDbContext.User.Add()
            //}
            //else
            //{   // update
            //}
            return Ok();
        }
    }
}