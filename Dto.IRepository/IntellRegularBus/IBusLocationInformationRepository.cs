using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRegularBus
{
    public interface IBusLocationInformationRepository : IRepository<Bus_Location_Information>
    {
        List<Bus_Location_Information> SearchInfoByBusLocationInformationWhere(BusLocationInformationSearchViewModel busLocationInformationSearchViewModel);
    }
}
