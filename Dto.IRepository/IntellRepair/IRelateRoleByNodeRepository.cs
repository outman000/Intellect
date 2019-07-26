using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRepair
{
   public interface IRelateRoleByNodeRepository : IRepository<Flow_Relate_NodeRole>
    {
        /// <summary>
        /// 给节点添加角色
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int RelateNodeToRoleAdd(List<Flow_Relate_NodeRole> list);
        /// <summary>
        /// 给节点删除角色
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int RelateNodeToRoleDel(List<int> list);
        /// <summary>
        /// 根据用户查角色
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        List<Flow_Relate_NodeRole> SearchRoleInfoByWhere(RoleByNodeSearchViewModel  roleByNodeSearchViewModel);
        /// <summary>
        /// 根据节点查询角色数量
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        IQueryable<Flow_Relate_NodeRole> Role_By_Node_Get_ALLNum(RoleByNodeSearchViewModel roleByNodeSearchViewModel);
    }
}
