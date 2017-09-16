using System.Web;
using System.Web.Mvc;
using NorthWind2.App_Start;
using NorthWindCoreData;
using StructureMap.Web.Pipeline;

namespace NorthWind2.DependencyResolution {
    public class StructureMapScopeModule : IHttpModule {
        #region Public Methods and Operators

        public void Dispose() {
        }

        public void Init(HttpApplication context) {
            context.BeginRequest += (sender, e) => StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
            context.EndRequest += (sender, e) =>
            {
                var unit = DependencyResolver.Current.GetService<IUnitOfWork>();
                unit.Commit();
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }

        #endregion
    }
}