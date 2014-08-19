using eManager.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace eManager.Web.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {

        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower().StartsWith("emp"))
            {
                var db = new DepartmentDb();
                var controller = new EmployeeController(db);
                return controller;

            }

            if (controllerName.ToLower().StartsWith("hom"))
            {
                var db = new DepartmentDb();
                var controller = new HomeController(db);
                return controller;

            }

            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);

        }

        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
           // throw new NotImplementedException();
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if(disposable !=null)
            {
                disposable.Dispose();
            }
        }
    }
}