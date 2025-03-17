using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SolarPanelsBelgium.Core.Data;
using SolarPanelsBelgium.Core.Entitites;
using SolarPanelsBelgium.Core.Services;
using SolarPanelsBelgium.Core.Services.Models.RequestModels;

namespace SolarPanelsBelgium.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly SolarPanelService _solarPanelService;
        private readonly FormBuilderService _formBuilderService;

        public AdminController(SolarPanelService solarPanelService, FormBuilderService formBuilderService)
        {
            _solarPanelService = solarPanelService;
            _formBuilderService = formBuilderService;
        }


        public async Task<IActionResult> Index()
        {
            var result = await _solarPanelService.GetAllAsync();

            if (result.IsSuccess)
                return View(result.Item);
            else
                return RedirectToAction("Error", "Home");
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

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _solarPanelService.GetByIdAsync(id);

            if (result.IsSuccess)
            {
                ViewData["Status"] = _formBuilderService.GetStatusDropDown();
                var solarPanel = result.Item;
                return View(solarPanel);
            }
            else
                return RedirectToAction("Error", "Home");
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
