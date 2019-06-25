using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.UserViewModel;
namespace IntellUser.Controllers
{
    [Route("UserApi/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        [HttpPost]

        public ActionResult UserLogin([FromBody] LoginViewModel obj)
        {
            var result = _InvestInterface.GetContractorData(obj);
            return Ok(result);
        }

    }
}