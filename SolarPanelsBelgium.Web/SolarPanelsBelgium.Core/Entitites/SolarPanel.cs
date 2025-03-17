using SolarPanelsBelgium.Core.Entitites.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Entitites
{
    public class SolarPanel
    {
        public int Id { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Area must be a positive number.")]
        public double Area { get; set; }

        [Required(ErrorMessage = "Wattage is required.")]
        public string Wattage { get; set; }

        [Display(Name = "Efficiency Class")]
        [Required(ErrorMessage = "Efficiency Class is required.")]
        public EfficiencyClass EfficiencyClass { get; set; }

        [Display(Name = "Roof Design")]
        [Required(ErrorMessage = "Roof Design is required.")]
        public RoofDesign RoofDesign { get; set; }

        [Display(Name = "Roof Orientation")]
        [Required(ErrorMessage = "Roof Orientation is required.")]
        [StringLength(50, ErrorMessage = "Roof orientation cannot exceed 50 characters.")]
        public string RoofOrientation { get; set; }

        [Display(Name = "Panel Type")]
        [Required(ErrorMessage = "Panel Type is required.")]
        public PanelType PanelType { get; set; }

        [Display(Name = "Date Submitted")]
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public double Price { get; set; }
        public Status Status { get; set; } = Status.New;

        public string ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
