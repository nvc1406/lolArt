using System;
using System.Collections.Generic;
using System.Linq;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;
using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.PageDefault
{
    public class PageDefaultController
    {
        private readonly PageDefaultResponsitory _pageDefaultResponsitory;
        private readonly LogExceptionController _logException;
        public PageDefaultController()
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
            _pageDefaultResponsitory = new PageDefaultResponsitory(unitOfWork);
            _logException = new LogExceptionController();
        }
        public List<Model.PageDefault> GetAll()
        {
            var objData = _pageDefaultResponsitory.GetAll();
            return objData.ToList();
        }
        public Model.PageDefault GetPageDefaultByUserId(int userId)
        {
            var objPage = _pageDefaultResponsitory.GetMany(t => t.UserId == userId).FirstOrDefault();
            return objPage;
        }

        public string AddPage(Model.PageDefault objPage)
        {
            try
            {
                if (objPage != null)
                {
                    _pageDefaultResponsitory.Insert(objPage);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                //var exMess = GetType() + ex.Message;
                _logException.InsertException(new Model.LogException { Exception = ex.Message, Time = DateTime.Now, FileException = GetType().ToString(), MethodName = "AddPage", StatusException = EnumKey.Running });
                return ex.Message;
            }
        }

        public string UpdatePage(Model.PageDefault objPageUpdate)
        {
            try
            {
                if (objPageUpdate != null)
                {
                    _pageDefaultResponsitory.Update(objPageUpdate);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                //var exMess = GetType() + ex.Message;
                _logException.InsertException(new Model.LogException { Exception = ex.Message, Time = DateTime.Now, FileException = GetType().ToString(), MethodName = "UpdatePage", StatusException = EnumKey.Running });
                return ex.Message;
            }
        }

        public string DeletePage(Model.PageDefault objPageDelete)
        {
            try
            {
                if (objPageDelete != null)
                {
                    _pageDefaultResponsitory.Delete(objPageDelete);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                var exMess = GetType() + ex.Message;
                _logException.InsertException(new Model.LogException { Exception = exMess, Time = DateTime.Now });
                return ex.Message;
            }
        }
    }

}
