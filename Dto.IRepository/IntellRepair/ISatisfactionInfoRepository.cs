using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRepair
{
    public interface ISatisfactionInfoRepository : IRepository<Satisfaction_Info>
    {

        // 根据条件查评价信息
        List<Satisfaction_Info> SearchInfoByRepairWhere(SatisfactionInfoSearchViewModel  satisfactionInfoSearchViewModel);
    }
}
