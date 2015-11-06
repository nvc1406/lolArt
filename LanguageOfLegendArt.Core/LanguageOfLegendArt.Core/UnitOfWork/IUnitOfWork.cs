using System.Data.Entity;

namespace LanguageOfLegendArt.Core.UnitOfWork
{
    public  interface IUnitOfWork
    {
        /// <summary>
        /// Call this to commit the unit of work
        /// </summary>
        void Commit();

        /// <summary>
        /// Return the database reference for this UOW
        /// </summary>
        DbContext Db { get; }

        /// <summary>
        /// Starts a transaction on this unit of work
        /// </summary>
        void StartTransaction();

    }
}
