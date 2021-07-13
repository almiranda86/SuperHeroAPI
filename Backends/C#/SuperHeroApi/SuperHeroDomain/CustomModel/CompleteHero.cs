using SuperHeroDomain.BaseModel;
using SuperHeroDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.CustomModel
{
    public class CompleteHero
    {
        public Powerstats Powerstats { get; set; }
        public Biography Biography { get; set; }
        public Appearance Appearance { get; set; }
        public Work Work { get; set; }
        public Connections Connections { get; set; }
        public Image Image { get; set; }
    }
}
