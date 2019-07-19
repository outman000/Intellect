using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel;

namespace Dto.IService.IntellRegularBus
{
    public interface ILineService
    {
        /// <summary>
        /// 查询线路信息
        /// </summary>
        /// <param name="lineSearchViewModel"></param>
        List<LineSearchMiddlecs> Line_Search(LineSearchViewModel lineSearchViewModel);
        /// <summary>
        /// 添加线路
        /// </summary>
        /// <param name="lineAddViewModel"></param>
        /// <returns></returns>
        int Line_Add(LineAddViewModel lineAddViewModel);
        /// <summary>
        /// 删除线路信息
        /// </summary>
        /// <param name="lineDelViewModel"></param>
        /// <returns></returns>
        int Line_Delete(LineDelViewModel lineDelViewModel);

        /// <summary>
        /// 更新线路信息
        /// </summary>
        /// <param name="lineUpdateViewModel"></param>
        /// <returns></returns>
        int Line_Update(LineUpdateViewModel lineUpdateViewModel);
        /// <summary>
        /// 验证线路的唯一性
        /// </summary>
        /// <param name="busValideRepeat"></param>
        /// <returns></returns>
        bool Line_Single(BusValideRepeat busValideRepeat);

       
    }
}
