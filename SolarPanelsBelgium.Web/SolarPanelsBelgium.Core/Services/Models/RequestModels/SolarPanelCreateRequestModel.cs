using SolarPanelsBelgium.Core.Entitites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Services.Models.RequestModels
{
    public class SolarPanelCreateRequestModel
    {
        public double Area { get; set; }
        public string Wattage { get; set; }
        public EfficiencyClass EfficiencyClass { get; set; }
        public RoofDesign RoofDesign { get; set; }
        public string RoofOrientation { get; set; }
        public PanelType PanelType { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
