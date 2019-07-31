using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.OpinionInfoViewModel.RequestViewModel;


namespace Dto.IService.IntellOpinionInfo
{
    public interface IOpinionInfoService
    {
        /// <summary>
        /// 添加领导回复意见
        /// </summary>
        /// <param name="opinionInfoAddViewModel"></param>
        /// <returns></returns>
        int OpinionInfo_Add(OpinionInfoAddViewModel  opinionInfoAddViewModel);

        /// <summary>
        /// 删除领导回复意见
        /// </summary>
        /// <param name="opinionInfoDelViewModel"></param>
        /// <returns></returns>
        int OpinionInfo_Delete(OpinionInfoDelViewModel  opinionInfoDelViewModel);

        /// <summary>
        /// 更新领导回复意见
        /// </summary>
        /// <param name="opinionInfoUpdateViewModel"></param>
        /// <returns></returns>
        int OpinionInfo_Update(OpinionInfoUpdateViewModel  opinionInfoUpdateViewModel);

        /// <summary>
        /// 查询领导回复意见
        /// </summary>
        /// <param name="opinionInfoSearchViewModel"></param>
        List<Opinion_Info> OpinionInfo_Search(OpinionInfoSearchViewModel  opinionInfoSearchViewModel);

        /// <summary>
        /// 获取领导回复意见总数
        /// </summary>
        /// <returns></returns>
        int OpinionInfo_Get_ALLNum(OpinionInfoSearchViewModel opinionInfoSearchViewModel);
    }
}
