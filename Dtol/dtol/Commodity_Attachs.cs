using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtol.dtol
{
    public class Commodity_Attachs
    {
        #region Model

        /// <summary>
        /// 
        /// </summary>
        [Key]
        [StringLength(50)]
        public string id
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string formid
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Catalog
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgIndex
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get; set;

        }
        /// <summary>
        /// 
        /// </summary>
        public string InternalName
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Length
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string creatorID
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createDate
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string bak1
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string bak2
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string bak3
        {
            get; set;
        }
        #endregion Model
    }
}
