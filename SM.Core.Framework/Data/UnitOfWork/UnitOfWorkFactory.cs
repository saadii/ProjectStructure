using System.Transactions;

namespace SM.Core.Framework.Data.UnitOfWork
{
    /// <summary>
    ///
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="scopeOptions"></param>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public IUnitOfWork CreateUnitOfWork(TransactionScopeOption scopeOptions = 0, IsolationLevel isolationLevel = (IsolationLevel)2)
        {
            return new UnitOfWork(scopeOptions, isolationLevel);
        }
    }
}