using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
namespace Utilities.CustomApi
{
    /// <summary>
    /// Helper to Create a SingleResult (200 OK) Response as IHttpActionResult
    /// </summary>
    /// <typeparam name="T">The type of item in query.</typeparam>
    /// <param name="itemQuery">The query to get the item.</param>
    /// <returns>A System.Web.Http.Results.JsonResult`1 with the specified values.</returns>
    //protected IHttpActionResult MySingleResult<T>(IQueryable<T> itemQuery)
    //{
    //    return Content(HttpStatusCode.OK, SingleResult.Create(itemQuery));
    //}
}
