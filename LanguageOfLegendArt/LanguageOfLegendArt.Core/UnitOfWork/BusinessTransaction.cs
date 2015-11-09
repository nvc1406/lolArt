using System;

namespace LanguageOfLegendArt.Core.UnitOfWork
{
    public class BusinessTransaction<TU> : IDisposable
    {
        private readonly IBaseRepository<TU> _dbService;
        public bool IsInTransaction { get; set; }
        public BusinessTransaction(IBaseRepository<TU> dbService)
        {
            _dbService = dbService;
            GetUnitOfWork().StartTransaction();
            IsInTransaction = true;
        }

        public void StartTransaction()
        {
            GetUnitOfWork().StartTransaction();
            IsInTransaction = true;
        }

        public void Complete()
        {
            GetUnitOfWork().Commit();
            IsInTransaction = false;
        }

        public void Dispose()
        {
            IsInTransaction = false;
            //GetUnitOfWork().Dispose();
        }

        private IUnitOfWork GetUnitOfWork()
        {
            return _dbService.UnitOfWork;
        }
    }
}
