using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.BusinessLogic
{
    public class BusinessLogicEngine
    {
        public IResult Run(params IResult[] businessRules)
        {
            foreach (var businessRule in businessRules) 
            {
                if (businessRule.IsSuccess is not true)
                    return businessRule;     
            }

            return null;
        }
    }
}
