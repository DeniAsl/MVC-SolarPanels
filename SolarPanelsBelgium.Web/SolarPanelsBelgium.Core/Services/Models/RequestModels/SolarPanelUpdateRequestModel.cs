using SolarPanelsBelgium.Core.Entitites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Services.Models.RequestModels
{
    public class SolarPanelUpdateRequestModel : SolarPanelCreateRequestModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public Status Status{ get; set; }
    }
}
