using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IService.IntellUser
{
  public interface IRightsService
    {
        // <summary>
        // 添加权限
        // </summary>
        // <param name = "rightsAddViewModel" ></ param >
        // < returns ></ returns >
        int Rights_Add(RightsAddViewModel rightsAddViewModel);
        /// <summary>
        /// 验证权限的唯一性
        /// </summary>
        /// <param name="rightsValideRepeat"></param>
        /// <returns></returns>
        bool Rights_Single(RightsValideRepeat rightsValideRepeat);
        // /// <summary>
        // /// 删除权限信息
        // /// </summary>
        // /// <param name="rightsDeleteViewModel"></param>
        // /// <returns></returns>
        int Rights_Delete(RightsDeleteViewModel rightsDeleteViewModel);
          // <summary>
          // 更新权限信息
          //</summary>
          // <param name="rightsUpdateViewModel"></param>
         // <returns></returns>
        int Rights_Update(RightsUpdateViewModel rightsUpdateViewModel);
        // /// <summary>
        // /// 查询权限信息
        // /// </summary>
        // /// <param name="rightsSearchViewModel"></param>
        List<RightsSearchMiddlecs> Rights_Search(RightsSearchViewModel rightsSearchViewModel);

        /// <summary>
        /// 获取权限总数
        /// </summary>
        /// <returns></returns>
        int Rights_Get_ALLNum();

    }
}
