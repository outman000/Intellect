using Dto.IRepository.IntellUser;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.RoomViewModel;
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.Repository.IntellUser
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<MeetingRoom_Information> DbSet;
        protected readonly DbSet<MeetingRoom_Reservation> DbSet1;
        protected readonly DbSet<DataBase_Type> DbSet2;

        public RoomInformationRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<MeetingRoom_Information>();
            DbSet1 = Db.Set<MeetingRoom_Reservation>();
            DbSet2 = Db.Set<DataBase_Type>();

        }
        public virtual void Add(MeetingRoom_Information obj)
        {

            DbSet.Add(obj);
        }

        public int AddByNum(MeetingRoom_Information obj)
        {
            int mex = 0;
            var model = DbSet.Where(a => a.RoomNum.ToString() == obj.RoomNum).ToList();
            if (model.Count <= 0)
            {
                DbSet.Add(obj);
            }
            else
            {
                mex = -1;
            }
            return mex;
        }


        public List<int> DeleteByRoomidList(List<string> IdList)
        {
            List<int> num = new List<int>();
            int DeleteFNum = 0;//删除失败数
            int DeleteRowNum = 0;//删除成功数
            for (int i = 0; i < IdList.Count; i++)
            {
                var model1 = DbSet1.Where(a => a.MeetingRoom_InformationId.ToString() == IdList[i] && a.Status == "0").ToList();
                if (model1.Count > 0)
                {
                    DeleteFNum += 1;
                }
                else
                {
                    var model = DbSet.Where(w => w.Id.ToString() == IdList[i] && w.Status == "0").ToList();
                    if (model.Count > 0)
                    {
                        model[0].IsDelete = "1";
                        DbSet.Update(model[0]);
                        SaveChanges();
                        DeleteRowNum++;

                    }
                    else
                    {
                        DeleteFNum += 1;
                    }
                }


            }
            num.Add(DeleteFNum);
            num.Add(DeleteRowNum);
            return num;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<MeetingRoom_Information> GetAll()
        {
            return DbSet;
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public MeetingRoom_Information GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Update(MeetingRoom_Information obj)
        {
            DbSet.Update(obj);
        }
        /// <summary>
        /// 根据会议室id查询预定状态
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public List<MeetingRoom_Reservation> GetReservationByInformation(string roomid, string dateTime)
        {
            var result = DbSet1.Where(A => A.MeetingRoom_InformationId.ToString() == roomid && A.Status == "0" &&
                                        A.Meetingtime.ToString("yyyy-MM-dd HH:mm").Contains(dateTime)).ToList();
            return result;
        }

        /// <summary>
        /// 根据id查会议室信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<MeetingRoom_Information> SearchInformationByid(string id)
        {
            var result = DbSet.Where(a => a.Id.ToString() == id).Include(a => a.DataBase_Type).OrderByDescending(a => a.CreateDate).ToList();

            return result;
        }
        public List<MeetingRoom_Information> SearchInformationNumById(string id)
        {
            var result = DbSet.Where(a => a.Id.ToString() == id).Include(a => a.DataBase_Type).OrderByDescending(a => a.CreateDate).ToList();

            return result;
        }
        /// <summary>
        /// 楼、区、会议室查询会议室信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<RoomInformationSearchMiddle> SearchRoomInformationWhere(RoomInformationSearchViewModel roomInformationSearchViewModel)
        {
            int SkipNum = roomInformationSearchViewModel.pageViewModel.CurrentPageNum * roomInformationSearchViewModel.pageViewModel.PageSize;

            var predicate = SearchRoominfo(roomInformationSearchViewModel);

            //var result = DbSet.Where(predicate).Include(a => a.DataBase_Type).OrderByDescending(a => a.CreateDate)
            //    .Skip(SkipNum)
            //    .Take(roomInformationSearchViewModel.pageViewModel.PageSize).ToList();
            var result = DbSet2.Where(D => D.Id.ToString().Contains(roomInformationSearchViewModel.FloorId)).Join(DbSet.Where(predicate).Include(c => c.DataBase_Type)
                    , a => a.Id.ToString(), D => D.DataBase_Type.Parentid, (a, D) => new RoomInformationSearchMiddle
                    {
                        Id = D.Id,
                        RoomNum = D.RoomNum,
                        RoomCapacity = D.RoomCapacity,
                        RoomDescription = D.RoomDescription,
                        RoomEquipmentCode = D.RoomEquipmentCode,
                        RoomEquipmentName = D.RoomEquipmentName,
                        Sort = D.Sort,
                        Status = D.Status,
                        IsDelete = D.IsDelete,
                        DataBase_TypeId = D.DataBase_TypeId.ToString(),
                        AreaName = D.DataBase_Type.Name,
                        FloorName = a.Name,

                    }).OrderByDescending(a => a.CreateDate)
                     .Skip(SkipNum)
                     .Take(roomInformationSearchViewModel.pageViewModel.PageSize).ToList();
            return result;
        }

        public List<MeetingRoom_Information> SearchRoomInformationNum(RoomInformationSearchViewModel roomInformationSearchViewModel)
        {

            var predicate = SearchRoominfo(roomInformationSearchViewModel);

            var result = DbSet.Where(predicate).ToList();
            return result;
        }

        #region 条件

        //根据条件查询会议室信息
        private Expression<Func<MeetingRoom_Information, bool>> SearchRoominfo(RoomInformationSearchViewModel roomInformationSearchViewModel)
        {
            var predicate = WhereExtension.True<MeetingRoom_Information>();//初始化where表达式

            predicate = predicate.And(a => a.IsDelete == "0");

            predicate = predicate.And(a => a.Id.ToString().Contains(roomInformationSearchViewModel.Id.ToString()));

            predicate = predicate.And(a => a.DataBase_TypeId.ToString().Contains(roomInformationSearchViewModel.AreaAll));

            predicate = predicate.And(a => a.DataBase_Type.Purview.Contains("(" + roomInformationSearchViewModel.departid + ")") || a.DataBase_Type.Purview.Contains("all"));

            return predicate;
        }
        #endregion

        //根据主键id查询
        public MeetingRoom_Information GetInfoByRoomid(Guid id)
        {
            MeetingRoom_Information meetingroom_Information = DbSet.Single(uid => uid.Id.Equals(id));
            return meetingroom_Information;
        }
        /// <summary>
        /// 根据区id查会议室
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<MeetingRoom_Information> SearchRoomByArea(string id)
        {
            var result = DbSet.Where(f => f.DataBase_TypeId.ToString() == id && f.IsDelete == "0").OrderByDescending(f => f.Sort).ToList();

            return result;
        }

        /// <summary>
        /// 根据会议室条件查询会议室信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<RoomInformationSearchMiddle> SearchRoomInfoByinfo(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel)
        {
            int SkipNum = roomInformationByInfoSearchViewModel.pageViewModel.CurrentPageNum * roomInformationByInfoSearchViewModel.pageViewModel.PageSize;

            var predicate = SearchinfoByinfo(roomInformationByInfoSearchViewModel);

            //var result = DbSet.Where(predicate).Include(a => a.DataBase_Type).OrderByDescending(a => a.CreateDate)
            //    .Skip(SkipNum)
            //    .Take(roomInformationByInfoSearchViewModel.pageViewModel.PageSize).ToList();
            var result = DbSet2.Where(D => D.Id.ToString().Contains(roomInformationByInfoSearchViewModel.FloorId)).Join(DbSet.Where(predicate).Include(c => c.DataBase_Type)
                    , a => a.Id.ToString(), D => D.DataBase_Type.Parentid, (a, D) => new RoomInformationSearchMiddle
                    {
                        Id = D.Id,
                        RoomNum = D.RoomNum,
                        RoomCapacity = D.RoomCapacity,
                        RoomDescription = D.RoomDescription,
                        RoomEquipmentCode = D.RoomEquipmentCode,
                        RoomEquipmentName = D.RoomEquipmentName,
                        Sort = D.Sort,
                        RoomStatus = D.RoomStatus,
                        Status = D.Status,
                        IsDelete = D.IsDelete,
                        CreateUser = D.CreateUser,
                        UpdateUser = D.UpdateUser,
                        CreateDate = D.CreateDate,
                        UpdateDate = D.UpdateDate,
                        DataBase_TypeId = D.DataBase_TypeId.ToString(),
                        AreaName = D.DataBase_Type.Name,
                        FloorName = a.Name,
                        Property = a.Property,
                        PropertyPhone = a.PropertyPhone,
                        //    Website = "http://172.30.10.202:5006/MobileServer/login.html"
                        Website = "http://zhfwpt.dongjiang.gov.cn/MobileServer/login.html"


                    }).OrderByDescending(a => a.CreateDate)
                     .Skip(SkipNum)
                     .Take(roomInformationByInfoSearchViewModel.pageViewModel.PageSize).ToList();
            return result;
        }

        #region 条件

        //根据条件查询会议室信息
        private Expression<Func<MeetingRoom_Information, bool>> SearchinfoByinfo(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<MeetingRoom_Information>();//初始化where表达式

            predicate = predicate.And(a => a.IsDelete == "0");

            predicate = predicate.And(a => a.Id.ToString().Contains(roomInformationByInfoSearchViewModel.Id.ToString()));

            predicate = predicate.And(a => a.DataBase_TypeId.ToString().Contains(roomInformationByInfoSearchViewModel.AreaAll));

            predicate = predicate.And(a => a.RoomEquipmentName.Contains(roomInformationByInfoSearchViewModel.RoomEquipmentName));

            if (roomInformationByInfoSearchViewModel.RoomCapacityLeast != null && roomInformationByInfoSearchViewModel.RoomCapacityMost != null)
                predicate = predicate.And(a => Convert.ToInt32(a.RoomCapacity) >= roomInformationByInfoSearchViewModel.RoomCapacityLeast &&
                Convert.ToInt32(a.RoomCapacity) <= roomInformationByInfoSearchViewModel.RoomCapacityMost);

            return predicate;
        }
        #endregion
        public List<RoomInformationSearchMiddle> SearchRoominfoByinfoNum(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel)
        {

            var predicate = SearchinfoByinfo(roomInformationByInfoSearchViewModel);

            var result = DbSet2.Where(D => D.Id.ToString().Contains(roomInformationByInfoSearchViewModel.FloorId)).Join(DbSet.Where(predicate).Include(c => c.DataBase_Type)
                    , a => a.Id.ToString(), D => D.DataBase_Type.Parentid, (a, D) => new RoomInformationSearchMiddle
                    {
                        Id = D.Id,
                        RoomNum = D.RoomNum,
                        RoomCapacity = D.RoomCapacity,
                        RoomDescription = D.RoomDescription,
                        RoomEquipmentCode = D.RoomEquipmentCode,
                        RoomEquipmentName = D.RoomEquipmentName,
                        Sort = D.Sort,
                        RoomStatus = D.RoomStatus,
                        Status = D.Status,
                        IsDelete = D.IsDelete,
                        CreateUser = D.CreateUser,
                        UpdateUser = D.UpdateUser,
                        CreateDate = D.CreateDate,
                        UpdateDate = D.UpdateDate,
                        DataBase_TypeId = D.DataBase_TypeId.ToString(),
                        AreaName = D.DataBase_Type.Name,
                        FloorName = a.Name,
                        Property = a.Property,
                        PropertyPhone = a.PropertyPhone,
                        Website = "http://172.30.10.202:5006/MobileServer/login.html"

                    }).OrderByDescending(a => a.CreateDate).ToList();
            return result;
        }
    }
}
