using BL.Interfaces;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private IProvidersService _providerService;
        //private readonly ILogger<ProvidersController> _logger;

        public AppointmentsController(
            //ILogger<ProvidersController> logger,
            IProvidersService providersService)
        {
            //_logger = logger;
            _providerService = providersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetProviders(string specialty, long date,float minScore)
        {
            try
            {
                if (specialty == string.Empty || specialty == null)
                    return BadRequest("Bad Parameters");
                var providers = await this._providerService.GetProviders(specialty, date,minScore);
                return Ok(this._providerService.SortProviders(providers));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> CanSchdeuleAppointment(CanScheduleAppointmentParams reqParams)
        {
            try
            {
                bool canSchedule = await this._providerService.CanScheduleAppointment(reqParams.Name, reqParams.Date);
                return canSchedule ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
    public class CanScheduleAppointmentParams
    {
        public string Name { get; set; }
        public long Date { get; set; }
    }
}
