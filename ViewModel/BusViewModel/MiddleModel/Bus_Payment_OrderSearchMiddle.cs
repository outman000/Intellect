﻿using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.OpinionInfoViewModel.MiddleModel;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class Bus_Payment_OrderSearchMiddle
    {
        public List<Bus_Payment_Search>  bus_Payments { get; set; }
        public  Bus_Payment_Order  bus_Payment_Order { get; set; }
        public List<OpinionInfoSearchMiddlecs> opinion_Infos { get; set; }
    }
}
