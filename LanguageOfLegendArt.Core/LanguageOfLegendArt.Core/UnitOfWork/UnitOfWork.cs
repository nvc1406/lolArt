using System.Data.Entity;
using System.Transactions;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Model;

namespace LanguageOfLegendArt.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly DataCenterEntities _db;
        public UnitOfWork()
        {
            _db = new DataCenterEntities();

        }
        public void Dispose()
        {

        }
        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }
        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }
        public DbContext Db
        {
            get { return _db; }
        }
    }
}
