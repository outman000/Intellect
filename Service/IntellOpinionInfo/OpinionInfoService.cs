using AutoMapper;
using Dto.IRepository.IntellOpinionInfo;
using Dto.IService.IntellOpinionInfo;

using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.OpinionInfoViewModel.RequestViewModel;


namespace Dto.Service.IntellSuggestBox
{
    public class OpinionInfoService : IOpinionInfoService
    {
        private readonly IOpinionInfoRepository _IOpinionInfoRepository;
        private readonly IMapper _IMapper;

        public OpinionInfoService(IOpinionInfoRepository  opinionInfoRepository, IMapper mapper)
        {
            _IOpinionInfoRepository = opinionInfoRepository;
            _IMapper = mapper;
        }
        /// <summary>
        /// 修改领导意见
        /// </summary>
        /// <param name="opinionInfoUpdateViewModel"></param>
        /// <returns></returns>
        public int OpinionInfo_Update(OpinionInfoUpdateViewModel opinionInfoUpdateViewModel)
        {
            var opinion_Info = _IOpinionInfoRepository.GetInfoByOpinionId(opinionInfoUpdateViewModel.Id);
            var opinion_Info_update = _IMapper.Map<OpinionInfoUpdateViewModel, Opinion_Info>(opinionInfoUpdateViewModel, opinion_Info);
            _IOpinionInfoRepository.Update(opinion_Info_update);
            return _IOpinionInfoRepository.SaveChanges();
        }

        /// <summary>
        /// 增加领导回复意见
        /// </summary>
        /// <param name="opinionInfoAddViewModel"></param>
        /// <returns></returns>
        public int OpinionInfo_Add(OpinionInfoAddViewModel opinionInfoAddViewModel)
        {
            var opinionInfo_Info = _IMapper.Map<OpinionInfoAddViewModel, Opinion_Info>(opinionInfoAddViewModel);
            _IOpinionInfoRepository.Add(opinionInfo_Info);
            return _IOpinionInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 删除领导回复意见
        /// </summary>
        /// <param name="opinionInfoDelViewModel"></param>
        /// <returns></returns>
        public int OpinionInfo_Delete(OpinionInfoDelViewModel opinionInfoDelViewModel)
        {
            int DeleteRowsNum = _IOpinionInfoRepository
               .DeleteByOpinionInfoIdList(opinionInfoDelViewModel.DeleleIdList);
            if (DeleteRowsNum == opinionInfoDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 根据条件查询领导意见
        /// </summary>
        /// <param name="opinionInfoSearchViewModel"></param>
        /// <returns></returns>
        public List<Opinion_Info> OpinionInfo_Search(OpinionInfoSearchViewModel opinionInfoSearchViewModel)
        {
           
           List<Opinion_Info> opinionInfo_Infos = _IOpinionInfoRepository.SearchOpinionInfoByWhere(opinionInfoSearchViewModel).ToList();
           return opinionInfo_Infos;
        }

        public int OpinionInfo_Get_ALLNum(OpinionInfoSearchViewModel opinionInfoSearchViewModel)
        {
            return _IOpinionInfoRepository.GetOpinionInfoAll(opinionInfoSearchViewModel).Count();
        }
    }
}
