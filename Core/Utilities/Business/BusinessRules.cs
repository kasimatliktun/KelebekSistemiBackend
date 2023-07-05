using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules//iş kuralları çıplak kalabilir.
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
