using System;

namespace SM.Core.Framework.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}