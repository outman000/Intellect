using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;

namespace Dto.IRepository.IntellRegularBus
{
    public interface IBusScanRecordRepository : IRepository<Bus_Scan_Record>
    {
        List<Bus_Scan_Record> SearchInfoByBusScanRecordWhere(BusScanRecordSearchViewModel busScanRecordSearchViewModel);
        List<Bus_Scan_Record> SearchInfoByBusScanRecordWhereNum(BusScanRecordSearchViewModel busScanRecordSearchViewModel);
    }
}
