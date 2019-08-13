using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BulletinBoardViewModel.ResponseModel
{
    public class BulletinBoardSearchResModel
    {
        public bool isSuccess;
        public List<BulletinBoardSearchMiddlecs> bulletinBoard_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public BulletinBoardSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
