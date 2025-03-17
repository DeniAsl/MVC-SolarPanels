using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Entitites.Enums
{
    public enum EfficiencyClass
    {
        [Display(Name = "A - Excellent")]
        A,

        [Display(Name = "B - Good")]
        B,

        [Display(Name = "C - Average")]
        C,

        [Display(Name = "D - Below Average")]
        D
    }
}
