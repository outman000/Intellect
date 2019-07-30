using System;
using System.Collections.Generic;
using System.Text;
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
        /// <param name = "foodInfoDelViewModel" ></ param >
        /// < returns ></ returns >
        //int Food_Delete(FoodInfoDelViewModel foodInfoDelViewModel);
        /// <summary>
        /// 查询菜单信息
        /// </summary>
        /// <param name = "foodInfoSearchViewModel" ></ param >
        //List < Food_Info > Food_Search(FoodInfoSearchViewModel foodInfoSearchViewModel);

        /// <summary>
        /// 获取菜单总数
        /// </summary>
        /// <returns></returns>
        //int Food_Get_ALLNum(FoodInfoSearchViewModel foodInfoSearchViewModel);
    }
}
