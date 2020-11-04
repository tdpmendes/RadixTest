using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RdxServer.Business;
using RdxServer.Business.Interfaces;
using RdxServer.Business.Response;
using RdxServer.DTO;

namespace RdxServer.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventBusiness _business;
        public EventsController(IEventBusiness business)
        {
            _business = business;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/events
        [HttpPost]
        public async Task<ActionResult<DeviceEventDTO>> Post([FromBody] DeviceEventDTO dvcEvt)
        {
            if (dvcEvt != null)
            {
                int value;
                int.TryParse(dvcEvt.Valor, out value);
                
                EventBusinessResponseVO response;
                response = await _business.ProcessEvent(dvcEvt);
                
                return Ok(response);
            } 
            else
            {
                return BadRequest(dvcEvt);
            }
        }

        // GET api/report
        [HttpGet("/report")]
        public async Task<ActionResult<EventGraphDTO>> Report()
        {
            EventGraphDTO eventGraph = await _business.GetReports();

            return Ok(eventGraph);
        }
    }
}
