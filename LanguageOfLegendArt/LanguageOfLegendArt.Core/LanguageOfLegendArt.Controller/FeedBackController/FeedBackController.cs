using System;
using System.Collections.Generic;
using System.Linq;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Model;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;
using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.FeedBackController
{
    public class FeedBackController
    {
        private readonly LogExceptionResponsitory _exceptionResponsitory;
        private readonly FeedBackResponsitory _feedResponsitory;

        public FeedBackController()
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
            _exceptionResponsitory = new LogExceptionResponsitory(unitOfWork);
            _feedResponsitory = new FeedBackResponsitory(unitOfWork);
        }

        public void AddFeedBack(FeedBack feedObj)
        {
            try
            {
                _feedResponsitory.Insert(feedObj);
            }
            catch (Exception ex)
            {
                _exceptionResponsitory.Insert(new Model.LogException
                {
                    FileException = GetType().ToString(),
                    Exception = ex.Message,
                    Time = DateTime.Now,
                    MethodName = "AddFeedBack",
                    StatusException = EnumKey.Running
                });
            }
        }

        public List<FeedBack> GetAllFeedBacks()
        {
            var lstData = _feedResponsitory.GetAll();
            return lstData.ToList();
        }
        public List<FeedBack> GetAllFeedNotReply()
        {
            var lstData = _feedResponsitory.GetMany(p => p.Status == EnumKey.Running).OrderBy(t => t.Time);
            return lstData.ToList();
        }

        public List<FeedBack> GetAllFeedBackInDay(DateTime day)
        {
            var lstData = _feedResponsitory.GetMany(t => t.Time.Day == day.Day).OrderByDescending(p => p.Time).ToList();
            return lstData;
        }

        public List<FeedBack> GetFeedBacksRangeTime(DateTime start, DateTime end)
        {
            var lstData =
                _feedResponsitory.GetMany(t => t.Time >= start && t.Time <= end)
                    .OrderByDescending(p => p.Time)
                    .ToList();
            return lstData;
        }

        public List<FeedBack> GetListFeedBacksByEmail(string name)
        {
            var lstData = !string.IsNullOrEmpty(name) ? _feedResponsitory.GetMany(t => t.Email.Contains(name)).ToList() : _feedResponsitory.GetAll().ToList();
            return lstData;
        }

        public List<FeedBack> GetAllFeedBacksByStatus(int status)
        {
            // nếu = 0 là get all : Tất cả.
            var lstData = status != 0 ? _feedResponsitory.GetMany(t => t.Status == status).ToList() : _feedResponsitory.GetAll().ToList();
            return lstData;
        }
        public List<FeedBack> GetAllFeedBacksByUserSupported(int userId)
        {
            // nếu = 0 là get all : Tất cả.
            var lstData = _feedResponsitory.GetMany(t => t.SupportedBy == userId).ToList();
            return lstData;
        }

        public List<FeedBack> GetAllByParam(string email, int staus, DateTime sTime, DateTime eTime)
        {
            var lstData = GetAllFeedBacks();

            if (!string.IsNullOrEmpty(email))
                lstData = lstData.Where(p => p.Email.Contains(email)).ToList();
            if (staus != 0)
                lstData = lstData.Where(p => p.Status == staus).ToList();
            if (sTime != DateTime.MinValue && eTime != DateTime.MinValue)
                lstData = lstData.Where(t => t.Time.Day >= sTime.Day && t.Time.Day <= eTime.Day).ToList();
            return lstData;
        }
    }
}
