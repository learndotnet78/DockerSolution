using Docker.Infrastructure.Repositories;
using Docker.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Docker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly DemoRepository demoRespository;
        public DemoController()
        {
            demoRespository = new DemoRepository();

        }

        [HttpGet]
        public IEnumerable<Demo> GetAllDemos()
        {
            IEnumerable<Demo> lstDemos = null;

            if (demoRespository != null)
            {
                lstDemos = demoRespository.GetDemos();
            }
            return lstDemos;
        }

        [HttpGet("{demoID}")]
        public IActionResult GetAllCustomerById(int demoID)
        {
            var demo = demoRespository.GetDemoById(demoID);
            return Ok(demo);
        }

        [HttpPost]
        [Route("AddDemo")]
        public IActionResult AddDemo([FromBody] Demo demo)
        {
            if (demo != null)
            {
                var objCustomer = demoRespository.AddDemo(demo);
                return Ok(objCustomer);
            }

            return Ok();
        }

        [HttpPost]
        [Route("UpdateDemo")]
        public IActionResult UpdateCustomer([FromBody] Demo demo)
        {
            if (demo != null)
            {
                var objDemo = demoRespository.UpdateDemo(demo);
                return Ok(objDemo);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDemo")]
        public JsonResult Delete(int demoID)
        {
            var boolVal = demoRespository.DeleteDemo(demoID);
            if (boolVal)
                return new JsonResult("Deleted Successfully.");
            else
                return new JsonResult("Demo was not deleted.");
        }
    }

}
