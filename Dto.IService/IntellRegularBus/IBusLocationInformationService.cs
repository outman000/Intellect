using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;

namespace Dto.IService.IntellRegularBus
{
    public interface IBusLocationInformationService
    {
        /// <summary>
        /// 添加班车位置信息
        /// </summary>
        /// <param name="busAddViewModel"></param>
        /// <returns></returns>
        int BusLocationInformation_Add(BusLocationInformationAddViewModel  busLocationInformationAddViewModel);
    }
}
