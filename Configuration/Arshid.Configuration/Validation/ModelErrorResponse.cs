using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arshid.Configuration.Validation
{
    public class ModelErrorResponse
    {

        public static ArshidResponse<Object> GetResponse(ModelStateDictionary ModelState, string defaultCode)
        {
            if (ModelState.Keys.First() == "")
            {
                var response = ArshidResponse<Object>.SetResponse(defaultCode + "200", "Invalid Model State.", null);
                return response;
            }

            var errorKeyFirst = ModelState.Keys.First();
            if (errorKeyFirst == null)
            {
                var response = ArshidResponse<Object>.SetResponse(defaultCode + "200", "Invalid Model State.", null);
                return response;
            }
            try
            {
                var errorStatus = ModelState[errorKeyFirst].Errors.First().ErrorMessage;
                if (errorStatus == "") errorStatus = "200"; // fix when parsing failures occur
                var response = ArshidResponse<Object>.SetResponse(defaultCode + errorStatus, errorKeyFirst, null);
                return response;
            }
            catch (Exception e)
            {
                var response = ArshidResponse<Object>.SetResponse(defaultCode + "200", "Invalid Model State.", null);
                return response;
            }
        }


    }
}
