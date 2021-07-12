using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.BaseModel
{
    public interface IDomainBaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
