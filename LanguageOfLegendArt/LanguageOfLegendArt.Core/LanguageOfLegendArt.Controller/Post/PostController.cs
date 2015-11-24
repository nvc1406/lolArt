using System;
using System.Collections.Generic;
using System.Linq;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.FeedBackController;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;
using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.Post
{
    public class PostController
    {
        private readonly LogExceptionController _exceptionController;
        private readonly PostResponsitory _postResponsitory;

        public PostController()
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
            _exceptionController = new LogExceptionController();
            _postResponsitory = new PostResponsitory(unitOfWork);
        }

        public List<Model.Post> GetAll()
        {
            var lstData = _postResponsitory.GetAll().ToList();
            return lstData;
        }

        public List<Model.Post> GetById(int id)
        {
            var lstData = _postResponsitory.GetMany(t => t.PostId == id).ToList();
            return lstData;
        }
        public List<Model.Post> GetByUserId(int uid)
        {
            var lstData = _postResponsitory.GetMany(t => t.PostBy == uid).ToList();
            return lstData;
        }

        public List<Model.Post> GetAllPostByCategory(int categoryId)
        {
            var lstData = _postResponsitory.GetMany(t => t.CategoryId == categoryId).ToList();
            return lstData;
        }

        public List<Model.Post> GetAllPostWaitting()
        {
            var lstData = _postResponsitory.GetMany(t => t.PostStatus == EnumKey.Waiting).OrderByDescending(t => t.PostTime).ToList();
            return lstData;
        }

        public List<Model.Post> GetAllPostAccepted()
        {
            var lstData = _postResponsitory.GetMany(t => t.PostStatus == EnumKey.Accepted).OrderByDescending(t => t.PostTime).ToList();
            return lstData;
        }

        public string CreatePost(Model.Post postObj)
        {
            string notification = string.Empty;
            try
            {
                _postResponsitory.Insert(postObj);
            }
            catch (Exception ex)
            {
                notification = ex.Message;
                _exceptionController.InsertException(new Model.LogException{FileException = GetType().ToString(),Exception = ex.Message,MethodName = "CreatePost",StatusException = EnumKey.Running,Time = DateTime.Now});
            }
            return notification;
        }

        public string UpdatePost(Model.Post postUpdateObj)
        {
            string notification = string.Empty;
            try
            {
                _postResponsitory.Update(postUpdateObj);
            }
            catch (Exception ex)
            {
                notification = ex.Message;
                _exceptionController.InsertException(new Model.LogException { FileException = GetType().ToString(), Exception = ex.Message, MethodName = "UpdatePost", StatusException = EnumKey.Running, Time = DateTime.Now });
            }
            return notification;
        }
    }
}
