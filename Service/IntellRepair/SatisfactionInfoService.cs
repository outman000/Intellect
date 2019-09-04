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
    public class SatisfactionInfoService : ISatisfactionInfoService
    {
        private readonly ISatisfactionInfoRepository _ISatisfactionInfoRepository;
      
        private readonly IMapper _IMapper;

        public SatisfactionInfoService(ISatisfactionInfoRepository  isatisfactionInfoRepository,
                            
                             IMapper mapper)
        {
            _ISatisfactionInfoRepository = isatisfactionInfoRepository;
       
            _IMapper = mapper;
        }
        /// <summary>
        /// 查询服务的评价信息
        /// </summary>
        /// <param name="satisfactionInfoAddViewModel"></param>
        /// <returns></returns>
        public List<SatisfactionInfoSearchMiddlecs> Satisfaction_Search(SatisfactionInfoSearchViewModel satisfactionInfoSearchViewModel)
        {
            List<Satisfaction_Info> satisfaction_Infos = _ISatisfactionInfoRepository.SearchInfoByRepairWhere(satisfactionInfoSearchViewModel);

            var satisfactionSearchMiddlecs = _IMapper.Map<List<Satisfaction_Info>, List<SatisfactionInfoSearchMiddlecs>>(satisfaction_Infos);
          
            return satisfactionSearchMiddlecs;
        }

        /// <summary>
        /// 添加对服务的评价信息
        /// </summary>
        /// <param name="satisfactionInfoAddViewModel"></param>
        /// <returns></returns>
        public int SatisfactionInfo_Add(SatisfactionInfoAddViewModel satisfactionInfoAddViewModel)
        {
            var node_Info = _IMapper.Map<SatisfactionInfoAddViewModel, Satisfaction_Info>(satisfactionInfoAddViewModel);
            _ISatisfactionInfoRepository.Add(node_Info);
            return _ISatisfactionInfoRepository.SaveChanges();
        }

        /// <summary>
        /// 查询服务的评价信息数量
        /// </summary>
        /// <param name="satisfactionInfoAddViewModel"></param>
        /// <returns></returns>
        public int Satisfaction_Get_ALLNum(SatisfactionInfoSearchViewModel satisfactionInfoSearchViewModel)
        {
            return _ISatisfactionInfoRepository.SearchInfoByRepairWhere(satisfactionInfoSearchViewModel).Count();
        }
    }
}
