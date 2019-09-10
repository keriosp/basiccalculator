using BasicCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicCalculatorCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicCalculatorController : Controller
    {

        
        [HttpPost]
        
        public ActionResult<double> Calculator([FromBody]Operation model)
        {
              double result;
             // JObject jsonResult = new JObject();
            switch (model.OperationType)
            {
                case OperationType.Addition:
                    result = model.NumberA + model.NumberB;
                    break;
                case OperationType.Substraction:
                    result = model.NumberA - model.NumberB;
                    break;
                case OperationType.Multiplication:
                    result = model.NumberA * model.NumberB;
                    break;
                case OperationType.Division:
                    result = model.NumberA / model.NumberB;
                    break;
                default:
                    result = 0;
                    break;
            }
           // jsonResult["NumberA"]= model.NumberA;
           // jsonResult["NumberB"] = model.NumberB;
           // jsonResult["Operation"] = model.OperationType.ToString();
           //jsonResult["Result"] = model.Result;
            return result;
        }
    }
}
