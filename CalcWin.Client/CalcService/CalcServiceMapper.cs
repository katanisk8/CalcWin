﻿using System.Net.Http;
using DataAccess.Model;

namespace CalcWin.Client.CalcService
{
    public class CalcServiceMapper : ICalcServiceMapper
    {
        public Result MapCalcServiceResponse(HttpResponseMessage response)
        {
            Result result = new Result();



            return result;
        }
    }
}