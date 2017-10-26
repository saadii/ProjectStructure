using System.Transactions;

namespace SM.Core.Framework.Data.UnitOfWork
{
    /// <summary>
    ///
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="scopeOptions"></param>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        IUnitOfWork CreateUnitOfWork(TransactionScopeOption scopeOptions = 0, IsolationLevel isolationLevel = (IsolationLevel)2);

        //IsolationLevel  = 2
    }
}