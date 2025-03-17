using Microsoft.EntityFrameworkCore;
using SolarPanelsBelgium.Core.Data;
using SolarPanelsBelgium.Core.Entitites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolarPanelsBelgium.Core.Services.Interfaces;

namespace SolarPanelsBelgium.Core.Services
{
    public class FormBuilderService : IFormBuilderService
    {
        private readonly ApplicationDbContext _context;

        public FormBuilderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetEfficiencyClassDropDown()
        {
            return Enum.GetValues(typeof(EfficiencyClass))
                .Cast<EfficiencyClass>()
                .Select(p => new SelectListItem
                {
                    Value = ((int)p).ToString(),
                    Text = p.ToString()
                })
                .ToList();
        }

        public IEnumerable<SelectListItem> GetPanelTypeDropDown()
        {
            return Enum.GetValues(typeof(PanelType))
                .Cast<PanelType>()
                .Select(p => new SelectListItem
                {
                    Value = ((int)p).ToString(),
                    Text = p.ToString()
                })
                .ToList();
        }

        public IEnumerable<SelectListItem> GetRoofDesignDropDown()
        {
            return Enum.GetValues(typeof(RoofDesign))
                .Cast<RoofDesign>()
                .Select(p => new SelectListItem
                {
                    Value = ((int)p).ToString(),
                    Text = p.ToString()
                })
                .ToList();
        }

        public IEnumerable<SelectListItem> GetStatusDropDown()
        {
            return Enum.GetValues(typeof(Status))
                .Cast<Status>()
                .Select(p => new SelectListItem
                {
                    Value = ((int)p).ToString(),
                    Text = p.ToString()
                })
                .ToList();
        }
    }
}
