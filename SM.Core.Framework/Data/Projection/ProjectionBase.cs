using System.Dynamic;

namespace SM.Core.Framework.Data.Projection
{
    public abstract class ProjectionBase : IProjection
    {
        /// <summary>
        ///
        /// </summary>
        protected ProjectionBase()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract ExpandoObject CreateParameters();
    }
}