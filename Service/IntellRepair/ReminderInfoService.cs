using AutoMapper;
using Dto.IRepository.IntellRepair;
using Dto.IService.IntellRepair;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Service.IntellRepair
{
    public class ReminderInfoService : IReminderInfoService
    {
        private readonly IReminderInfoRepository _IReminderInfoRepository;

        private readonly IMapper _IMapper;

        public ReminderInfoService(IReminderInfoRepository  ireminderInfoRepository,IMapper mapper)
        {
            _IReminderInfoRepository = ireminderInfoRepository;
            _IMapper = mapper;
        }
        
        /// <summary>
        /// 增加催单信息
        /// </summary>
        /// <param name="reminderInfoAddViewModel"></param>
        /// <returns></returns>
        public int ReminderInfo_Add(ReminderInfoAddViewModel reminderInfoAddViewModel)
        {
            var reminderInfo_Info = _IMapper.Map<ReminderInfoAddViewModel, Reminder_Info>(reminderInfoAddViewModel);
            _IReminderInfoRepository.Add(reminderInfo_Info);
            return _IReminderInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 查询催单数量
        /// </summary>
        /// <param name="reminderInfoSearchViewModel"></param>
        /// <returns></returns>
        public int ReminderInfo_Get_ALLNum(ReminderInfoSearchViewModel reminderInfoSearchViewModel)
        {
            return _IReminderInfoRepository.SearchInfoByReminderWhere(reminderInfoSearchViewModel).Count();
        }

        /// <summary>
        /// 查询催单信息
        /// </summary>
        /// <param name="reminderInfoSearchViewModel"></param>
        /// <returns></returns>
        public List<ReminderInfoSearchMiddlecs> ReminderInfo_Search(ReminderInfoSearchViewModel reminderInfoSearchViewModel)
        {
            List<Reminder_Info> reminder_Infos = _IReminderInfoRepository.SearchInfoByReminderWhere(reminderInfoSearchViewModel);

            var satisfactionSearchMiddlecs = _IMapper.Map<List<Reminder_Info>, List<ReminderInfoSearchMiddlecs>>(reminder_Infos);

            return satisfactionSearchMiddlecs;
        }
    }
}
