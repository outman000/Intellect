using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SuggestBoxViewModel.MiddleModel;
using ViewModel.SuggestBoxViewModel.RequestViewModel;

namespace Dto.IService.IntellSuggestBox
{
    public interface ISuggestBoxService
    {
        /// <summary>
        /// 添加意见箱表单
        /// </summary>
        /// <param name="suggestBoxAddViewModel"></param>
        /// <returns></returns>
        int SuggestBox_Add(SuggestBoxAddViewModel  suggestBoxAddViewModel);

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="suggestBoxUpdateViewModel"></param>
        /// <returns></returns>
        int SuggestBox_Update(SuggestBoxUpdateViewModel  suggestBoxUpdateViewModel);
        
        /// <summary>
        /// 删除菜单信息
        /// </summary>
        /// <param name = "suggestBoxDelViewModel" ></ param >
        /// < returns ></ returns >
        int SuggestBox_Delete(SuggestBoxDelViewModel  suggestBoxDelViewModel);
        /// <summary>
        /// 查询菜单信息
        /// </summary>
        /// <param name = "suggestBoxSearchViewModel" ></ param >
        List<SuggestInfoMiddlecs> SuggestBox_Search(SuggestBoxSearchViewModel  suggestBoxSearchViewModel);

        /// <summary>
        /// 获取菜单总数
        /// </summary>
        /// <returns></returns>
        int SuggestBox_Get_ALLNum(SuggestBoxSearchViewModel suggestBoxSearchViewModel);

        /// <summary>
        /// 意见类型查询
        /// </summary>
        /// <param name="suggestBoxTypeSearchViewModel"></param>
        /// <returns></returns>

        List<Suggest_Box_Type> SuggestBoxType_Search(SuggestBoxTypeSearchViewModel suggestBoxTypeSearchViewModel);



        /// <summary>
        /// 根据用户主键Id查询意见箱
        /// </summary>
        /// <param name="suggestBoxSearchViewModel"></param>
        /// <returns></returns>
        List<SuggestInfoMiddlecs> SuggestBoxById_Search(SuggestBoxByIdSearchViewModel suggestBoxByIdSearchViewModel);

        /// <summary>
        /// 根据主键ID查询意见箱
        /// </summary>
        /// <param name="suggestBoxSearchByIdViewModel"></param>
        /// <returns></returns>
        SuggestInfoMiddlecs SuggestBox_SearchById(SuggestBoxSearchByIdViewModel suggestBoxSearchByIdViewModel);
    }
}
