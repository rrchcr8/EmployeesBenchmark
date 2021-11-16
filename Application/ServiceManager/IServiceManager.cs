using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceManager
{
    public interface IServiceManager
    {
        public CampaignService CampaignService { get; }
    }
}
