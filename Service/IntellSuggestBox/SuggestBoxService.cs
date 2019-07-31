using AutoMapper;
using Dto.IRepository.IntellSuggestBox;
using Dto.IService.IntellSuggestBox;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SuggestBoxViewModel.RequestViewModel;

namespace Dto.Service.IntellSuggestBox
{
    public class SuggestBoxService : ISuggestBoxService
    {
        private readonly ISuggestBoxRepository _ISuggestBoxRepository;
        private readonly IMapper _IMapper;

        public SuggestBoxService(ISuggestBoxRepository  suggestBoxRepository, IMapper mapper)
        {
            _ISuggestBoxRepository = suggestBoxRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 意见箱表单修改
        /// </summary>
        /// <param name="suggestBoxUpdateViewModel"></param>
        /// <returns></returns>
        public int SuggestBox_Update(SuggestBoxUpdateViewModel suggestBoxUpdateViewModel)
        {
            var suggestBox_Info = _ISuggestBoxRepository.GetInfoBySuggestBoxId(suggestBoxUpdateViewModel.Id);
            var suggestBox_Info_update = _IMapper.Map<SuggestBoxUpdateViewModel, Suggest_Box>(suggestBoxUpdateViewModel, suggestBox_Info);
            _ISuggestBoxRepository.Update(suggestBox_Info_update);
            return _ISuggestBoxRepository.SaveChanges();
        }

        /// <summary>
        /// 意见箱表单增加
        /// </summary>
        /// <param name="suggestBoxAddViewModel"></param>
        /// <returns></returns>
        public int SuggestBox_Add(SuggestBoxAddViewModel suggestBoxAddViewModel)
        {

            var suggestBox_Info = _IMapper.Map<SuggestBoxAddViewModel, Suggest_Box>(suggestBoxAddViewModel);
            _ISuggestBoxRepository.Add(suggestBox_Info);
            return _ISuggestBoxRepository.SaveChanges();
        }

        public int SuggestBox_Delete(SuggestBoxDelViewModel suggestBoxDelViewModel)
        {
            int DeleteRowsNum = _ISuggestBoxRepository
               .DeleteByFoodInfoIdList(suggestBoxDelViewModel.DeleleIdList);
            if (DeleteRowsNum == suggestBoxDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 意见箱表单查询
        /// </summary>
        /// <param name="suggestBoxSearchViewModel"></param>
        /// <returns></returns>
        public List<Suggest_Box> SuggestBox_Search(SuggestBoxSearchViewModel suggestBoxSearchViewModel)
        {
            List<Suggest_Box> suggestBox = _ISuggestBoxRepository.SearchSuggestBoxInfoByWhere(suggestBoxSearchViewModel);
            return suggestBox;
        }

        public int SuggestBox_Get_ALLNum(SuggestBoxSearchViewModel suggestBoxSearchViewModel)
        {
            return _ISuggestBoxRepository.GeSuggestBoxAll(suggestBoxSearchViewModel).Count();
        }
    }
}
