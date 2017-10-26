using System;
using System.Transactions;

namespace SM.Core.Framework.Data.UnitOfWork
{
    /// <summary>
    ///
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        ///
        /// </summary>
        private readonly TransactionScope scope;

        /// <summary>
        ///
        /// </summary>
        /// <param name="scopeOptions"></param>
        /// <param name="isolationLevel"></param>
        public UnitOfWork(TransactionScopeOption scopeOptions, IsolationLevel isolationLevel)
        {
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = isolationLevel
            };
            this.scope = new TransactionScope(scopeOptions, transactionOptions);
        }

        /// <summary>
        ///
        /// </summary>
        public void Commit()
        {
            if (this.scope != null)
            {
                this.scope.Complete();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="disposing"></param>

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.scope.Dispose();
            }
        }

        /// <summary>
        ///
        /// </summary>
        ~UnitOfWork()
        {
            this.Dispose(false);
        }
    }
}