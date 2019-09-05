using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRepair
{
    public interface IReminderInfoRepository : IRepository<Reminder_Info>
    {
        // 根据条件查评价信息
        List<Reminder_Info> SearchInfoByReminderWhere(ReminderInfoSearchViewModel reminderInfoSearchViewModel);
    }
}
