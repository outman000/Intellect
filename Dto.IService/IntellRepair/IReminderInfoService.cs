using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IService.IntellRepair
{
    public interface IReminderInfoService
    {
        /// <summary>
        /// 添加对服务的评价信息
        /// </summary>
        /// <param name="reminderInfoAddViewModel"></param>
        /// <returns></returns>
        int ReminderInfo_Add(ReminderInfoAddViewModel  reminderInfoAddViewModel);


        /// <summary>
        /// 查询服务的评价信息
        /// </summary>
        /// <param name="reminderInfoSearchViewModel"></param>
        List<ReminderInfoSearchMiddlecs> ReminderInfo_Search(ReminderInfoSearchViewModel  reminderInfoSearchViewModel);
    }
}
