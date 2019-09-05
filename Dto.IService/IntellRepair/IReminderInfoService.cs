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
        /// 添加催单信息
        /// </summary>
        /// <param name="reminderInfoAddViewModel"></param>
        /// <returns></returns>
        int ReminderInfo_Add(ReminderInfoAddViewModel  reminderInfoAddViewModel);


        /// <summary>
        /// 查询催单信息
        /// </summary>
        /// <param name="reminderInfoSearchViewModel"></param>
        List<ReminderInfoSearchMiddlecs> ReminderInfo_Search(ReminderInfoSearchViewModel  reminderInfoSearchViewModel);

        /// <summary>
        /// 查询催单信息数量
        /// </summary>
        /// <param name="satisfactionInfoSearchViewModel"></param>
        /// <returns></returns>
        int ReminderInfo_Get_ALLNum(ReminderInfoSearchViewModel reminderInfoSearchViewModel);
    }
}
