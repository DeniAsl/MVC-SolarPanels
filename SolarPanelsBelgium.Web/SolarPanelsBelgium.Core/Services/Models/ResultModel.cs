using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Services.Models
{
    public class ResultModel<T> : BaseResultModel
    {
        public T Item { get; set; }
    }
}
