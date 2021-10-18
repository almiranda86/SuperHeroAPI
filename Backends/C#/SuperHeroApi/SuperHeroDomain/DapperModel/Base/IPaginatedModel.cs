using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.DapperModel.Base
{
    public interface IPaginatedModel
    {
        int LINE_NUMBER { get; set; }
        
        int TOTAL_ROWS { get; set; }
    }
}
