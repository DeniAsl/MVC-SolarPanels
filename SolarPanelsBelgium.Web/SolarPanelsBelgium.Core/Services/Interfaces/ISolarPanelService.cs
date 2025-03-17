using SolarPanelsBelgium.Core.Entitites;
using SolarPanelsBelgium.Core.Services.Models;
using SolarPanelsBelgium.Core.Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Services.Interfaces
{
    public interface ISolarPanelService
    {
        Task<ResultModel<SolarPanel>> GetByIdAsync(int id);
        Task<ResultModel<List<SolarPanel>>> GetAllAsync();
        Task<BaseResultModel> CreateAsync(SolarPanelCreateRequestModel solarPanelCreateRequestModel);
        Task<BaseResultModel> UpdateAsync(SolarPanelUpdateRequestModel solarPanelUpdateRequestModel);
        Task<BaseResultModel> DeleteAsync(int id);
        IQueryable<SolarPanel> GetAll();
        Task<BaseResultModel> SaveChangesAsync();
        Task<ResultModel<SolarPanel>> GetMyRequest(string userId);
        Task<BaseResultModel> OnlyOneRequestCheck(string userId);
    }
}
