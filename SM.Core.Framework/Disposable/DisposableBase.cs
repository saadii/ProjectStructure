using System;

namespace SM.Core.Framework.Disposable
{
    /// <summary>
    /// Base class for implementing Disposable Pattern. See: http://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.71).aspx
    /// Derived classes should override protected virtual void Dispose(boo disposing) method.
    /// <example>
    /// public class Derived: Base
    ///{
    ///   protected override void Dispose(bool disposing)
    ///   {
    ///      if (disposing)
    ///      {
    ///         // Release managed resources.
    ///      }
    ///      // Release unmanaged resources.
    ///      // Set large fields to null.
    ///      // Call Dispose on your base class.
    ///      base.Dispose(disposing);
    ///   }
    ///   // The derived class does not have a Finalize method
    ///   // or a Dispose method with parameters because it inherits
    ///   // them from the base class.
    ///}
    /// </example>
    /// </summary>
    public class DisposableBase : IDisposable
    {
        /// <summary>
        /// Destructor.
        /// </summary>
        ~DisposableBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// IDisposable implementation.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposable pattern implementation.
        /// </summary>
        /// <param name="disposing">Disposing switch to release managed / unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 1. Free other state (managed objects).
            }

            // 2. Free your own state (unmanaged objects).

            // 3. Set large fields to null.
        }
    }
}