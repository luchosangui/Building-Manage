﻿using APIModels.InputModels;
using APIModels.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogic
{
    public interface ICategoryServiceLogic
    {

        public CategoryServiceResponse CreateCategoryservice(CategoryServiceRequest categoryServiceRequest);
    }
}
