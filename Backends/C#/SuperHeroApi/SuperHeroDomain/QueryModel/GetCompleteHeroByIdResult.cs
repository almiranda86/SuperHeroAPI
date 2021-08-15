using SuperHeroCore;
using SuperHeroDomain.BaseModel;
using SuperHeroDomain.Model;

namespace SuperHeroDomain.QueryModel
{
    public class GetCompleteHeroByIdResult : ServiceResponse, IDomainBaseModel, IResponseBaseModel
    {
        public string Response { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Powerstats Powerstats { get; set; }
        public Biography Biography { get; set; }
        public Appearance Appearance { get; set; }
        public Work Work { get; set; }
        public Connections Connections { get; set; }
        public Image Image { get; set; }
    }
}
