using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SolarPanelsBelgium.Core.Services.Interfaces
{
    interface IFormBuilderService
    {
        IEnumerable<SelectListItem> GetEfficiencyClassDropDown();
        IEnumerable<SelectListItem> GetPanelTypeDropDown();
        IEnumerable<SelectListItem> GetRoofDesignDropDown();
        IEnumerable<SelectListItem> GetStatusDropDown();
    }
}
