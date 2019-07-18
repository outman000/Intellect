using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

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

    }
}
