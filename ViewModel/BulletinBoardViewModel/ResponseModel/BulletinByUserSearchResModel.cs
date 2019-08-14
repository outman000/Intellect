using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BulletinBoardViewModel.ResponseModel
{
    public class BulletinByUserSearchResModel
    {
        public bool IsSuccess;
        public BulletinBoardRoleSearchMiddlecs userInfo;
        public BaseViewModel baseViewModel;
        public BulletinByUserSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
