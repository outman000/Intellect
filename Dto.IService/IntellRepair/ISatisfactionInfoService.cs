using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IService.IntellRepair
{
    public interface ISatisfactionInfoService
    {
        /// <summary>
        /// 添加对服务的评价信息
        /// </summary>
        /// <param name="satisfactionInfoAddViewModel"></param>
        /// <returns></returns>
        int SatisfactionInfo_Add(SatisfactionInfoAddViewModel satisfactionInfoAddViewModel);

        /// <summary>
        /// 查询服务的评价信息
        /// </summary>
        /// <param name="satisfactionInfoSearchViewModel"></param>
        List<SatisfactionInfoSearchMiddlecs> Satisfaction_Search(SatisfactionInfoSearchViewModel  satisfactionInfoSearchViewModel);

        /// <summary>
        /// 查询服务的评价信息数量
        /// </summary>
        /// <param name="satisfactionInfoSearchViewModel"></param>
        /// <returns></returns>
        int Satisfaction_Get_ALLNum(SatisfactionInfoSearchViewModel satisfactionInfoSearchViewModel);
    }
}
