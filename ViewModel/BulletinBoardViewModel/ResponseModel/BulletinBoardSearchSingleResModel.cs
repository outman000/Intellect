using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BulletinBoardViewModel.ResponseModel
{
    public class BulletinBoardSearchSingleResModel
    {
        public bool isSuccess;
        public BulletinBoardSearchMiddlecs bulletinBoard_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public BulletinBoardSearchSingleResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
