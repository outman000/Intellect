using AutoMapper;
using Dto.IRepository.IntellRepair;
using Dto.IService.IntellRepair;
using Dtol.dtol;
using System;
using System.Collections.Generic;
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

        public List<ReminderInfoSearchMiddlecs> ReminderInfo_Search(ReminderInfoSearchViewModel reminderInfoSearchViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
