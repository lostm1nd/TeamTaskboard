namespace TeamTaskboard.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Data.Entity;
    using System.Web.Mvc;

    using AutoMapper;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    
    using TeamTaskboard.Data.Contracts;

    public abstract class KendoGridController : AdminBaseController
    {
        public KendoGridController(ITaskboardData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.GetData().ToDataSourceResult(request);
            return this.Json(data);
        }

        protected abstract IEnumerable GetData();

        protected abstract T GetById<T>(object id) where T : class;

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model == null || !ModelState.IsValid)
            {
                return null;
            }

            var dbModel = Mapper.Map<T>(model);
            this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
            return dbModel;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : class
            where TViewModel : class
        {
            if (model == null || !ModelState.IsValid)
            {
                return;
            }

            var entity = this.GetById<TModel>(id);
            Mapper.Map<TViewModel, TModel>(model, entity);
            this.ChangeEntityStateAndSave(entity, EntityState.Modified);
        }

        [NonAction]
        protected virtual void Destroy<TModel>(object id) where TModel : class
        {
            var entity = this.GetById<TModel>(id);
            this.ChangeEntityStateAndSave(entity, EntityState.Deleted);
        }

        protected JsonResult GridOperation<T>([DataSourceRequest]DataSourceRequest request, T model)
        {
            return this.Json((new[] { model }).ToDataSourceResult(request, this.ModelState));
        }

        private void ChangeEntityStateAndSave(object entity, EntityState state)
        {
            var entry = this.Data.Context.Entry(entity);
            entry.State = state;
            this.Data.SaveChanges();
        }        
    }
}