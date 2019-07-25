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
    public class RepairService : IRepairService
    {
        private readonly IRepairInfoRepository _IRepairInfoRepository;
        private readonly IMapper _IMapper;

        public RepairService(IRepairInfoRepository irepairInfoRepository, IMapper mapper)
        {
            _IRepairInfoRepository = irepairInfoRepository;

            _IMapper = mapper;
        }

        /// <summary>
        /// 报修表单查询
        /// </summary>
        /// <param name="repairInfoSearchViewModel"></param>
        /// <returns></returns>
        public List<RepairInfoSearchMiddlecs> Repair_Search(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            RepairInfoSearchMiddlecs repairSearches = new RepairInfoSearchMiddlecs();
            List<Repair_Info> line_Infos = _IRepairInfoRepository.SearchInfoByRepairWhere(repairInfoSearchViewModel).ToList();

            var repairSearchMiddlecs = _IMapper.Map< List<Repair_Info>, List<RepairInfoSearchMiddlecs>>(line_Infos);
             
            return repairSearchMiddlecs;
        }

        /// <summary>
        /// 添加报修表单
        /// </summary>
        /// <param name="repairAddViewModel"></param>
        /// <returns></returns>
        public int Repair_Add(RepairAddViewModel repairAddViewModel)
        {

            var repair_Info = _IMapper.Map<RepairAddViewModel, Repair_Info>(repairAddViewModel);
            _IRepairInfoRepository.Add(repair_Info);
            return _IRepairInfoRepository.SaveChanges();
        }

        /// <summary>
        /// 删除报修表单（一个或者多个）
        /// </summary>
        /// <param name="repairDelViewModel"></param>
        /// <returns></returns>
        public int Repair_Delete(RepairDelViewModel repairDelViewModel)
        {
            int DeleteRowsNum = _IRepairInfoRepository
                 .DeleteByRepairIdList(repairDelViewModel.DeleleIdList);
            if (DeleteRowsNum == repairDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 报修表单更新
        /// </summary>
        /// <param name="repairUpdateViewModel"></param>
        /// <returns></returns>
        public int Repair_Update(RepairUpdateViewModel repairUpdateViewModel)
        {
            var repair_Info = _IRepairInfoRepository.GetInfoByRepairId(repairUpdateViewModel.id);
            var repair_Info_update = _IMapper.Map<RepairUpdateViewModel, Repair_Info>(repairUpdateViewModel, repair_Info);
            _IRepairInfoRepository.Update(repair_Info_update);
            return _IRepairInfoRepository.SaveChanges();
        }
    }
}
