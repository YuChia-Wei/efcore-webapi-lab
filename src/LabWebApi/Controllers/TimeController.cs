﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace LabWebApi.Controllers
{
    /// <summary>
    /// Time
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        /// <summary>
        /// 直接轉出 DateTime
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("ConvertToLocal")]
        public IActionResult ConvertToLocal([FromQuery] DateTime input)
        {
            return Ok(input.ToLocalTime());
        }

        /// <summary>
        /// 直接轉出 DateTime
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("ConvertToUtc")]
        public IActionResult ConvertToUtc([FromQuery] DateTime input)
        {
            return Ok(input.ToUniversalTime());
        }

        /// <summary>
        /// 直接轉出 DateTime
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("Direct")]
        public IActionResult Direct([FromQuery] DateTime input)
        {
            return Ok(input);
        }
    }
}