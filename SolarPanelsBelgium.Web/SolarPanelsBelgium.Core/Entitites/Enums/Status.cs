using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Entitites.Enums
{
    public enum Status
    {
        New,
        [Display(Name = "In Progress")]
        InProgress,
        Done
    }
}
