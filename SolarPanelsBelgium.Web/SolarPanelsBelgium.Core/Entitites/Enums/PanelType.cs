using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Entitites.Enums
{
    public enum PanelType
    {
        [Display(Name = "Monocrystalline - High end")]
        Monocrystalline,

        [Display(Name = "Polycrystalline - Good")]
        Polycrystalline,

        [Display(Name = "Thinfilm - Average")]
        Thinfilm
    }
}
