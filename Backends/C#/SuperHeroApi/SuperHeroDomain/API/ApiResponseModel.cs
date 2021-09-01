using SuperHeroDomain.BaseModel;
using SuperHeroDomain.CustomModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.API
{
    public class ApiResponseModel : CompleteHero, IResponseBaseModel
    {
        public string Response { get; set; }
    }
}
