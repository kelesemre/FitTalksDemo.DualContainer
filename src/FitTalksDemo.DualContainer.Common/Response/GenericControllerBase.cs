using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitTalksDemo.DualContainer.Common.Response
{
    public class GenericControllerBase : ControllerBase
    {
        /// <summary>
        /// Wrap objectResults in the controller class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public IActionResult CreateActionResultInstance<T>(IGenericResponse<T> response)
        {
            return new ObjectResult(response);
        }
    }
}
