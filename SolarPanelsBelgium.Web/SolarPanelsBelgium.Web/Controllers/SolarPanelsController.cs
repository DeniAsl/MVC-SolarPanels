using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolarPanelsBelgium.Core.Data;
using SolarPanelsBelgium.Core.Entitites;
using SolarPanelsBelgium.Core.Services;
using SolarPanelsBelgium.Core.Services.Models.RequestModels;

namespace SolarPanelsBelgium.Web.Controllers
{

    [Authorize(Roles = "Customer")]
    public class SolarPanelsController : Controller
    {
        private readonly SolarPanelService _solarPanelService;
        private readonly FormBuilderService _formBuilderService;

        public SolarPanelsController(SolarPanelService solarPanelService, FormBuilderService formBuilderService)
        {
            _solarPanelService = solarPanelService;
            _formBuilderService = formBuilderService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _solarPanelService.GetMyRequest(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (result.IsSuccess)
                return View(result.Item);
            else
                return View(result.Item);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _solarPanelService.GetByIdAsync(id);

            if (result.IsSuccess)
            {
                var solarPanel = result.Item;
                return View(solarPanel);
            }
            else
                return RedirectToAction("Error", "Home");
        }

        public async Task<IActionResult> Create()
        {
            var check = _solarPanelService.OnlyOneRequestCheck(User.FindFirstValue(ClaimTypes.NameIdentifier)).Result;
            if (!check.IsSuccess)
            {
                TempData["Error"] = check.Errors;
                return RedirectToAction(nameof(Index));
            }

            ViewData["EfficiencyClass"] = _formBuilderService.GetEfficiencyClassDropDown();
            ViewData["RoofDesign"] = _formBuilderService.GetRoofDesignDropDown();
            ViewData["PanelType"] = _formBuilderService.GetPanelTypeDropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Area,Wattage,EfficiencyClass,RoofDesign,RoofOrientation,PanelType,DateSubmitted")] SolarPanel solarPanel)
        {
            ModelState.Remove("ApplicationUserId");
            if (ModelState.IsValid)
            {
                var solarPanelCreateRequestModel = new SolarPanelCreateRequestModel()
                {
                    Area = solarPanel.Area,
                    Wattage = solarPanel.Wattage,
                    EfficiencyClass = solarPanel.EfficiencyClass,
                    PanelType = solarPanel.PanelType,
                    RoofDesign = solarPanel.RoofDesign,
                    RoofOrientation = solarPanel.RoofOrientation,
                    ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                var result = await _solarPanelService.CreateAsync(solarPanelCreateRequestModel);

                if (result.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction("Error", "Home");
            }

            ViewData["EfficiencyClass"] = _formBuilderService.GetEfficiencyClassDropDown();
            ViewData["RoofDesign"] = _formBuilderService.GetRoofDesignDropDown();
            ViewData["PanelType"] = _formBuilderService.GetPanelTypeDropDown();
            return View(solarPanel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _solarPanelService.GetByIdAsync(id);
            if (result.Item == null)
                return NotFound();

            var solarPanel = result.Item;

            ViewData["EfficiencyClass"] = _formBuilderService.GetEfficiencyClassDropDown();
            ViewData["RoofDesign"] = _formBuilderService.GetRoofDesignDropDown();
            ViewData["PanelType"] = _formBuilderService.GetPanelTypeDropDown();
            return View(solarPanel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Area,Wattage,EfficiencyClass,RoofDesign,RoofOrientation,PanelType,DateSubmitted,Price,Status,ApplicationUserId")] SolarPanel solarPanel)
        {
            if (ModelState.IsValid)
            {
                var solarPanelUpdateRequestModel = new SolarPanelUpdateRequestModel()
                {
                    Id = solarPanel.Id,
                    Area = solarPanel.Area,
                    Wattage = solarPanel.Wattage,
                    EfficiencyClass = solarPanel.EfficiencyClass,
                    PanelType = solarPanel.PanelType,
                    RoofDesign = solarPanel.RoofDesign,
                    RoofOrientation = solarPanel.RoofOrientation,
                    Price = solarPanel.Price,
                    Status = solarPanel.Status,
                    ApplicationUserId = solarPanel.ApplicationUserId
                };

                var result = await _solarPanelService.UpdateAsync(solarPanelUpdateRequestModel);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction("Error", "Home");
            }

            ViewData["EfficiencyClass"] = _formBuilderService.GetEfficiencyClassDropDown();
            ViewData["RoofDesign"] = _formBuilderService.GetRoofDesignDropDown();
            ViewData["PanelType"] = _formBuilderService.GetPanelTypeDropDown();
            return View(solarPanel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _solarPanelService.GetByIdAsync(id);
            if (result.Item == null)
                return NotFound();

            var solarPanel = result.Item;

            return View(solarPanel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _solarPanelService.DeleteAsync(id);
            if (result.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction("Error", "Home");
        }
    }
}
