using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

namespace Dto.IService.IntellRegularBus
{
    public interface IBusUserService
    {
        int Bus_User_Add(BusUserAddViewModel busUserAddViewModel);
    }
}
