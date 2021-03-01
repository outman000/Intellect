using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dto.IRepository.IntellUser;
using ViewModel.RoomViewModel.RequestViewModel;
using System.Linq.Expressions;
using Dtol.EfCoreExtion;

namespace Dto.Repository.IntellUser
{
    public class RoomReservationRepository : IRoomReservationRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<MeetingRoom_Reservation> DbSet;
        protected readonly DbSet<MeetingRoom_Information> DbSet1;

        public RoomReservationRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<MeetingRoom_Reservation>();
            DbSet1 = Db.Set<MeetingRoom_Information>();

        }
        public virtual void Add(MeetingRoom_Reservation obj)
        {

            DbSet.Add(obj);
        }
        /// <summary>
        /// 根据预订信息id查询预定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<MeetingRoom_Reservation> SearchReservationByid(string Id)
        {
            var model = DbSet.Where(w => w.Id.ToString() == Id && w.IsDelete == "0")
                .Include(a => a.MeetingRoom_Information).ThenInclude(A => A.DataBase_Type).OrderByDescending(a => a.CreateDate).ToList();
            return model;
        }
        public List<int> DeleteByReservationidList(List<string> IdList)
        {
            List<int> num = new List<int>();
            int DeleteFNum = 0;//删除失败数
            int DeleteRowNum = 0;//删除成功数
            for (int i = 0; i < IdList.Count; i++)
            {
                var model = DbSet.Where(w => w.Id.ToString() == IdList[i] && w.Status == "0" && w.IsDelete == "0").ToList();
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
            num.Add(DeleteFNum);
            num.Add(DeleteRowNum);
            return num;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<MeetingRoom_Reservation> GetAll()
        {
            return DbSet;
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public MeetingRoom_Reservation GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Update(MeetingRoom_Reservation obj)
        {
            DbSet.Update(obj);
        }
        /// <summary>
        /// 根据会议室信息id查询会议室预定信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<MeetingRoom_Reservation> SearchRoomReservationByid(string id)
        {

            var result = DbSet.Where(a => a.MeetingRoom_InformationId.ToString() == id && a.IsDelete == "0" && a.Status == "0")
                .Include(a => a.MeetingRoom_Information).OrderByDescending(a => a.CreateDate).ToList();

            return result;
        }

        /// <summary>
        /// 根据会议室id查询全部预定信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<MeetingRoom_Reservation> SearchReservationAllByid(string id)
        {

            var result = DbSet.Where(a => a.MeetingRoom_InformationId.ToString() == id && a.IsDelete == "0")
                .Include(a => a.MeetingRoom_Information).ThenInclude(A => A.DataBase_Type).OrderByDescending(a => a.CreateDate).ToList();

            return result;
        }
        /// <summary>
        /// 会议室预定信息查询
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<MeetingRoom_Reservation> SearchRoomReservationWhere(RoomReservationSearchViewModel roomReservationSearchViewModel)
        {
            int SkipNum = roomReservationSearchViewModel.pageViewModel.CurrentPageNum * roomReservationSearchViewModel.pageViewModel.PageSize;

            var predicate = SearchReservationinfo(roomReservationSearchViewModel);

            var result = DbSet.Where(predicate).Include(a => a.MeetingRoom_Information).OrderByDescending(a => a.CreateDate)
                .Skip(SkipNum)
                .Take(roomReservationSearchViewModel.pageViewModel.PageSize).ToList();

            return result;
        }

        public List<MeetingRoom_Reservation> SearchRoomReservationNum(RoomReservationSearchViewModel roomReservationSearchViewModel)
        {

            var predicate = SearchReservationinfo(roomReservationSearchViewModel);
            var result = DbSet.Where(predicate).Include(a => a.MeetingRoom_Information).OrderByDescending(a => a.CreateDate).ToList();
            return result;
        }
        #region 条件

        //根据条件查询会议室预定信息
        private Expression<Func<MeetingRoom_Reservation, bool>> SearchReservationinfo(RoomReservationSearchViewModel roomReservationSearchViewModel)
        {
            var predicate = WhereExtension.True<MeetingRoom_Reservation>();//初始化where表达式

            predicate = predicate.And(a => a.IsDelete == "0");

            predicate = predicate.And(a => a.CreateUser.Contains(roomReservationSearchViewModel.CreateUser));//

            predicate = predicate.And(a => a.DepartName.Contains(roomReservationSearchViewModel.DepartName));

            predicate = predicate.And(a => a.Phone.Contains(roomReservationSearchViewModel.Phone));

            predicate = predicate.And(a => a.MeetingContent.Contains(roomReservationSearchViewModel.MeetingContent));

            if (roomReservationSearchViewModel.RoomStatus == "")
            {
                predicate = predicate.And(a => a.RoomStatus == "1" || a.RoomStatus == "3");
            }
            else
            {
                predicate = predicate.And(a => a.RoomStatus.Contains(roomReservationSearchViewModel.RoomStatus));
            }

            predicate = predicate.And(a => a.Floor.Contains(roomReservationSearchViewModel.Floor));//

            predicate = predicate.And(a => a.Area.Contains(roomReservationSearchViewModel.Area));//

            predicate = predicate.And(a => a.ParticipantsNum.Contains(roomReservationSearchViewModel.ParticipantsNum.ToString()));//

            predicate = predicate.And(a => a.LeadershipWhether.Contains(roomReservationSearchViewModel.LeadershipWhether.ToString()));//

            predicate = predicate.And(a => a.Leadership.Contains(roomReservationSearchViewModel.Leadership.ToString()));//

            predicate = predicate.And(a => a.TeaWhether.Contains(roomReservationSearchViewModel.TeaWhether.ToString()));//

            predicate = predicate.And(a => a.MeetingRoom_InformationId.ToString().Contains(roomReservationSearchViewModel.MeetingRoom_InformationId));

            return predicate;
        }
        #endregion
        /// <summary>
        /// 会议室预定信息大屏显示
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<MeetingRoom_Reservation> SearchReservationMaxWhere(ReservationMaxSearchViewModel reservationMaxSearchViewModel)
        {
            int SkipNum = reservationMaxSearchViewModel.pageViewModel.CurrentPageNum * reservationMaxSearchViewModel.pageViewModel.PageSize;

            var predicate = SearchReservationMax(reservationMaxSearchViewModel);

            var result = DbSet.Where(predicate).Include(a => a.MeetingRoom_Information).OrderByDescending(a => a.CreateDate)
                .Skip(SkipNum)
                .Take(reservationMaxSearchViewModel.pageViewModel.PageSize).ToList();

            return result;
        }
        public List<MeetingRoom_Reservation> SearchReservationMaxNum(ReservationMaxSearchViewModel reservationMaxSearchViewModel)
        {

            var predicate = SearchReservationMax(reservationMaxSearchViewModel);
            var result = DbSet.Where(predicate).Include(a => a.MeetingRoom_Information).OrderByDescending(a => a.CreateDate).ToList();
            return result;
        }
        #region 条件

        //根据条件查询会议室预定信息
        private Expression<Func<MeetingRoom_Reservation, bool>> SearchReservationMax(ReservationMaxSearchViewModel reservationMaxSearchViewModel)
        {
            var predicate = WhereExtension.True<MeetingRoom_Reservation>();//初始化where表达式

            predicate = predicate.And(a => a.IsDelete == "0");

            if (reservationMaxSearchViewModel.RoomStatus == "")
            {
                predicate = predicate.And(a => a.RoomStatus == "1" || a.RoomStatus == "3");
            }
            else
            {
                predicate = predicate.And(a => a.RoomStatus.Contains(reservationMaxSearchViewModel.RoomStatus));
            }

            predicate = predicate.And(a => a.Floor.Contains(reservationMaxSearchViewModel.Floor));//

            return predicate;
        }
        #endregion
    }
}
