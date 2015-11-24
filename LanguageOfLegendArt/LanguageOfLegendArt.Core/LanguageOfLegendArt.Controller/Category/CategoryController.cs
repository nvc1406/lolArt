using System;
using System.Collections.Generic;
using System.Linq;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;
using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.Category
{
    public class CategoryController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryResponsitory _categoryResponsitory;
        private readonly LogExceptionController _logException;
        public CategoryController()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
            _categoryResponsitory = new CategoryResponsitory(_unitOfWork);
            _logException = new LogExceptionController();
        }
        public List<Model.Category> GetAll()
        {
            var lstData = _categoryResponsitory.GetAll().ToList();
            return lstData;
        }
        /// <summary>
        /// Hàm lấy ra Category theo ParentId
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Model.Category> GetAllByParentId(int parentId)
        {
            var lstData = _categoryResponsitory.GetMany(t => t.ParentId == parentId && t.CategoryStatus == EnumKey.Running).ToList();
            return lstData;
        }
        /// <summary>
        /// Hàm lấy ra tất cả các menu cha. Quy định parentId = 0.
        /// </summary>
        /// <returns></returns>
        public List<Model.Category> GetAllBaseCategory()
        {
            var lstData = _categoryResponsitory.GetMany(t => t.ParentId == 0 && t.CategoryStatus == EnumKey.Running).ToList();
            return lstData;
        }
        /// <summary>
        /// Lấy danh sách category theo trạng thái.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Model.Category> GetAllByStatus(int status)
        {
            var lstData = _categoryResponsitory.GetMany(t => t.CategoryStatus == status).ToList();
            return lstData;
        }
        /// <summary>
        /// Thêm mới cateogory
        /// </summary>
        /// <param name="objCategory"></param>
        /// <returns></returns>
        public int Create(Model.Category objCategory)
        {
            int iNotifi = 0;
            try
            {
                if (objCategory != null)
                {
                    _categoryResponsitory.Insert(objCategory);
                    iNotifi = EnumKey.InsertSuccess;
                }
            }
            catch (Exception ex)
            {
                //var mes = GetType() + ex.Message;
                _logException.InsertException(new Model.LogException { Exception = ex.Message, Time = DateTime.Now, FileException = GetType().ToString(), MethodName = "Create", StatusException = EnumKey.Running });
                iNotifi = EnumKey.InsertFail;
            }
            return iNotifi;
        }
        /// <summary>
        /// Hàm sửa danh mục
        /// </summary>
        /// <param name="obCategory"></param>
        public void Update(Model.Category obCategory)
        {
            try
            {
                if (obCategory != null)
                {
                    _categoryResponsitory.Update(obCategory);
                }
            }
            catch (Exception ex)
            {
                //var mes = GetType() + ex.Message;
                _logException.InsertException(new Model.LogException { Exception = ex.Message, Time = DateTime.Now, FileException = GetType().ToString(),MethodName = "Update",StatusException = EnumKey.Running});
            }
        }
    }
}
