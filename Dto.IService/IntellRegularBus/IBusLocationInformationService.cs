using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel;

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

        /// <summary>
        /// 根据条件查询车辆经纬度
        /// </summary>
        /// <param name="busLocationInformationSearchViewModel"></param>
        /// <returns></returns>
       BusLocationInformationSearchMiddle BusLocationInformation_Search(BusLocationInformationSearchViewModel  busLocationInformationSearchViewModel);

        /// <summary>
        /// 根据条件查询车辆基本信息
        /// </summary>
        /// <param name="busLocationInformationSearchViewModel"></param>
        /// <returns></returns>
        BusBasicSearchMiddle BusBasic_Search(BusLocationInformationSearchViewModel busLocationInformationSearchViewModel);
    }
}
