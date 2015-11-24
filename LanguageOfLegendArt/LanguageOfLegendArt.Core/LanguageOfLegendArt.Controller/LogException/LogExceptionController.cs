using System;
using System.Collections.Generic;
using System.Linq;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;
using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException
{
    public class LogExceptionController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LogExceptionResponsitory _exceptionResponsitory;

        public LogExceptionController()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
            _exceptionResponsitory = new LogExceptionResponsitory(_unitOfWork);
        }

        public void InsertException(Model.LogException exception)
        {
            try
            {
                _exceptionResponsitory.Insert(exception);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public List<Model.LogException> GetAllException()
        {
            var lstData = _exceptionResponsitory.GetAll();
            return lstData.ToList();
        }
        public List<Model.LogException> GetAllExceptionNotFixed()
        {
            var lstData = _exceptionResponsitory.GetMany(p => p.StatusException == EnumKey.Running).OrderByDescending(t => t.Time);
            return lstData.ToList();
        }

        public List<Model.LogException> GetAllExceptionInDay(DateTime day)
        {
            var lstData = _exceptionResponsitory.GetMany(t => t.Time.Day == day.Day).OrderByDescending(p=>p.Time).ToList();
            return lstData;
        }

        public List<Model.LogException> GetExceptionRangeTime(DateTime start, DateTime end)
        {
            var lstData =
                _exceptionResponsitory.GetMany(t => t.Time >= start && t.Time <= end)
                    .OrderByDescending(p => p.Time)
                    .ToList();
            return lstData;
        }

        public List<Model.LogException> GetListExceptionByTimeAndExceptions(string exception, DateTime start,DateTime end)
        {
            var lstData = new List<Model.LogException>();
            if ((start > DateTime.MinValue) && (end > DateTime.MinValue))
            {
                 if(start == DateTime.MinValue)
                    start = DateTime.Now;
                if(end == DateTime.MinValue)
                    end = DateTime.Now;
                lstData = _exceptionResponsitory.GetMany(t => t.Time >= start && t.Time <= end).ToList();
            }
           
            if (!string.IsNullOrEmpty(exception))
            {
                lstData = lstData.Where(t => t.Exception.Equals(exception)).ToList();
            }
            return lstData;
        }
    }
}
