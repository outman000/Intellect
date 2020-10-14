using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class UploadFileMiddleModel
    {  
        /// <summary>
       /// 
       /// </summary>
        public string Catalog { set; get; }
        /// <summary>
        /// 文件上传时名称，包括扩展名
        /// </summary>
        public string FileName { set; get; }
        /// <summary>
        /// 文件上传成功后生产的名称，包括扩展名
        /// </summary>
        public string InternalName { set; get; }
        /// <summary>
        /// 浏览路径
        /// </summary>
        public string Url { set; get; }
        /// <summary>
        /// 物理路径
        /// </summary>
        public string Path { set; get; }
        /// <summary>
        /// 手机物理路径
        /// </summary>
        public string Physicspath { set; get; }

        /// <summary>
        /// 网址路径
        /// </summary>
        public string path_server { set; get; }

        /// <summary>
        /// 上传进度
        /// </summary>
        public string upload_percent { set; get; }

        /// <summary>
        /// 上传的图片编号(提供给前端判断图片是否全部上传完)
        /// </summary>
        public int ImgIndex { get; set; }

        /// <summary>
        /// 上传的图片的大小
        /// </summary>
        public string Length { get; set; }
    }
}
