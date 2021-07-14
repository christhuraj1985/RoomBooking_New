using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBookingAPI.Models;
using RoomBookingAPI.Services;
using RoomBookingAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        ILoggerManager _logger;
        RoomServices _roomServices;
        public RoomController(ILoggerManager logger, RoomServices roomServices)
        {
            _logger = logger;
            _roomServices = roomServices;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var room = new List<Room>();
            try
            {
                room = _roomServices.Get();
                return new JsonResult(room);
            }
            catch (Exception ex)
            {
                _logger.LogInfo("Error Occured While getting all Room!, Please check the below object!");
                _logger.LogInfo($"{room} \n");
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        [HttpGet]
        public JsonResult Get(string id)
        {
            var room = new Room();
            try
            {
                room = _roomServices.Get(id);
                return new JsonResult(room);
            }
            catch (Exception ex)
            {
                _logger.LogInfo("Error Occurd while fetching Room!, Please check below object!");
                _logger.LogInfo($"{room} \n");
                _logger.LogError($"{ex.ToString()} \n");
                throw;
            }
        }

        [HttpPost]
        public JsonResult Post(string id)
        {
            var room = new Room();
            try
            {
                room = _roomServices.Get(id);
                return new JsonResult(room);
            }
            catch (Exception ex)
            {
                _logger.LogInfo("Error Occurd while fetching Room!, Please check below object!");
                _logger.LogInfo($"{room} \n");
                _logger.LogError($"{ex.ToString()} \n");
                throw;
            }

        }
    }
}
