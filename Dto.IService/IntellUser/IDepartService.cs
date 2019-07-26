using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.MiddleModel;

using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IService.IntellUser
{
    public interface IDepartService
    {
        // <summary>
        // 添加部门
        // </summary>
        // <param name = "departAddViewModel" ></ param >
        // < returns ></ returns >
        int Depart_Add(DepartAddViewModel departAddViewModel);

        /// <summary>
        /// 验证部门的唯一性
        /// </summary>
        /// <param name="departValideRepeat"></param>
        /// <returns></returns>
        bool Depart_Single(DepartValideRepeat departValideRepeat);
        // /// <summary>
        // /// 删除部门信息
        // /// </summary>
        // /// <param name="departDeleteViewModel"></param>
        // /// <returns></returns>
        int Depart_Delete(DepartDeleteViewModel departDeleteViewModel);
        // /// <summary>
        // /// 更新部门信息
        // /// </summary>
        // /// <param name="departUpdateViewModel"></param>
        // /// <returns></returns>
        int Depart_Update(DepartUpdateViewModel departUpdateViewModel);
        // /// <summary>
        // /// 查询部门信息
        // /// </summary>
        // /// <param name="departSearchViewModel"></param>
        List<DepartSearchMiddlecs> Depart_Search(DepartSearchViewModel departSearchViewModel);
        /// <summary>
        /// 获取部门总数
        /// </summary>
        /// <returns></returns>
        int Depart_Get_ALLNum(DepartSearchViewModel departSearchViewModel);
        /// <summary>
        /// 获取部门总数
        /// </summary>
        /// <returns></returns>
        int Depart_Get_ALLNum();
    }
}
