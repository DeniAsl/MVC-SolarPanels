using Microsoft.EntityFrameworkCore;
using SolarPanelsBelgium.Core.Data;
using SolarPanelsBelgium.Core.Entitites;
using SolarPanelsBelgium.Core.Entitites.Enums;
using SolarPanelsBelgium.Core.Services.Interfaces;
using SolarPanelsBelgium.Core.Services.Models;
using SolarPanelsBelgium.Core.Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SolarPanelsBelgium.Core.Services
{
    public class SolarPanelService : ISolarPanelService
    {
        private readonly ApplicationDbContext _context;

        public SolarPanelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BaseResultModel> OnlyOneRequestCheck(string userId)
        {
            var solarPanel = await _context.SolarPanels.FirstOrDefaultAsync(c => c.ApplicationUserId == userId);
            if (solarPanel != null)
            {
                return new BaseResultModel
                {
                    IsSuccess = false,
                    Errors = new List<string> { "You can only have one solar panel request", "You can update your existing request though" }
                };
            }
            return new BaseResultModel { IsSuccess = true };
        }

        public async Task<BaseResultModel> CreateAsync(SolarPanelCreateRequestModel solarPanelCreateRequestModel)
        {
            var sP = new SolarPanel();
            sP.Area = solarPanelCreateRequestModel.Area;
            sP.Wattage = solarPanelCreateRequestModel.Wattage;
            sP.EfficiencyClass = solarPanelCreateRequestModel.EfficiencyClass;
            sP.RoofOrientation = solarPanelCreateRequestModel.RoofOrientation;
            sP.RoofDesign = solarPanelCreateRequestModel.RoofDesign;
            sP.PanelType = solarPanelCreateRequestModel.PanelType;
            sP.ApplicationUserId = solarPanelCreateRequestModel.ApplicationUserId;

            await _context.SolarPanels.AddAsync(sP);
            return await SaveChangesAsync();
        }

        public async Task<BaseResultModel> UpdateAsync(SolarPanelUpdateRequestModel SolarPanelUpdateRequestModel)
        {
            ResultModel<SolarPanel> resultModel = await GetByIdAsync(SolarPanelUpdateRequestModel.Id);

            if (!resultModel.IsSuccess)
            {
                return new BaseResultModel()
                {
                    IsSuccess = false,
                    Errors = resultModel.Errors
                };
            }

            SolarPanel sP = resultModel.Item;

            sP.Area = SolarPanelUpdateRequestModel.Area;
            sP.Wattage = SolarPanelUpdateRequestModel.Wattage;
            sP.EfficiencyClass = SolarPanelUpdateRequestModel.EfficiencyClass;
            sP.RoofOrientation = SolarPanelUpdateRequestModel.RoofOrientation;
            sP.RoofDesign = SolarPanelUpdateRequestModel.RoofDesign;
            sP.PanelType = SolarPanelUpdateRequestModel.PanelType;
            sP.Price = SolarPanelUpdateRequestModel.Price;
            sP.Status = SolarPanelUpdateRequestModel.Status;
            sP.ApplicationUserId = SolarPanelUpdateRequestModel.ApplicationUserId;

            return await SaveChangesAsync();
        }

        public async Task<BaseResultModel> DeleteAsync(int id)
        {
            ResultModel<SolarPanel> resultModel = await GetByIdAsync(id);

            if (!resultModel.IsSuccess)
            {
                return new BaseResultModel()
                {
                    IsSuccess = false,
                    Errors = resultModel.Errors
                };
            }

            SolarPanel sP = resultModel.Item;

            _context.SolarPanels.Remove(sP);

            return await SaveChangesAsync();
        }


        public IQueryable<SolarPanel> GetAll()
        {
            return _context.SolarPanels.AsQueryable();
        }

        public async Task<ResultModel<List<SolarPanel>>> GetAllAsync()
        {
            try
            {
                return new ResultModel<List<SolarPanel>>
                {
                    IsSuccess = true,
                    Item = await _context.SolarPanels
                    .Include(c => c.ApplicationUser)
                    .ToListAsync()
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return new ResultModel<List<SolarPanel>>
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"A unknown error occurred. Please try again later.\n{exception}" },
                };
            }
        }

        public async Task<ResultModel<SolarPanel>> GetMyRequest(string userId)
        {
            var sP = await _context.SolarPanels.FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (sP == null)
            {
                return new ResultModel<SolarPanel>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Solar panel request not found" }
                };
            }

            return new ResultModel<SolarPanel>
            {
                IsSuccess = true,
                Item = sP
            };
        }

        public async Task<ResultModel<SolarPanel>> GetByIdAsync(int id)
        {
            SolarPanel sP = await _context.SolarPanels
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (sP == null)
            {
                return new ResultModel<SolarPanel>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Solar panel request not found" }
                };
            }

            return new ResultModel<SolarPanel>
            {
                IsSuccess = true,
                Item = sP
            };
        }

        public async Task<BaseResultModel> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return new BaseResultModel { IsSuccess = true };
            }
            catch (DbUpdateException dbUpdateException)
            {
                Console.WriteLine(dbUpdateException.Message);
                return new BaseResultModel
                {
                    IsSuccess = false,
                    Errors = new List<string> { "A unknown error occurred. Please try again later." },
                };
            }
        }
    }
}
