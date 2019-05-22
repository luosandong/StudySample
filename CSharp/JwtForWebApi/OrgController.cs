using ExOrg.Filters;
using ExOrg.Models.ViewModels;
using ExOrg.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Unity;

namespace ExOrg.Controllers
{
    [ApiAuthentication]
    public class OrgController : BaseController
    {
        [Dependency]
        public IOrgService OrgService { get; set; }
        [Dependency]
        public IFieldSettingsService FieldSettingsService { get; set; }
        #region 获取根组织
        [Route("api/org/root")]
        [HttpGet]
        public JsonResult<ResultMessage> GetOrgRoot()
        {
            ResultMessage result = new Models.ViewModels.ResultMessage();
            var root = OrgService.GetRoot();
            result.Data = root;
            result.StatusCode = Models.MessageCodeEnum.Success;
            result.Info = "";
            return Json(result);
        }
        #endregion

        #region 获取子组织
        [Route("api/org/subOrgs")]
        [HttpGet]
        public JsonResult<ResultMessage> GetOrgsByparent(GetOrgsByParentRequestMessage org)
        {
            ResultMessage result = new Models.ViewModels.ResultMessage();
            var root = OrgService.GetOrgsByParent(org.OrgParent);
            result.Data = root;
            result.StatusCode = Models.MessageCodeEnum.Success;
            result.Info = "";
            return Json(result);
        }
        #endregion

        #region 获取组织内员工
        [Route("api/org/employees")]
        [HttpGet]
        public JsonResult<ResultMessage> GetEmployeesByOrgId(GetEmployeesByOrgIdRequestMessage org)
        {
            ResultMessage result = new Models.ViewModels.ResultMessage();
            var employees = OrgService.GetMembers(org.OrgId);
            foreach (var item in employees)
            {
                item.HighlightWords = new List<string>();
                item.HighlightWords.Add("总");
                item.HighlightWords.Add("经");
                item.HighlightWords.Add("理");
                item.HighlightWords.Add("室");
            }
            result.Data = employees;
            result.StatusCode = Models.MessageCodeEnum.Success;
            result.Info = "";
            return Json(result);
        }
        #endregion

        #region 搜索员工
        [Route("api/employee/search")]
        [HttpGet]
        public JsonResult<ResultMessage> SearchMembers(SearchRequestMessage sr)
        {
            try
            {
                ResultMessage result = new Models.ViewModels.ResultMessage();
                var root = OrgService.GetMembers(sr.OrgId);
                result.Data = root;
                result.StatusCode = Models.MessageCodeEnum.Success;
                result.Info = "";
                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 获取字段配置
        [Route("api/settings/fieldsettings")]
        [HttpGet]
        public JsonResult<ResultMessage> GetFieldSettings(GetFieldSettingsRequestMessage sr)
        {
            try
            {
                ResultMessage result = new Models.ViewModels.ResultMessage();
                var root = FieldSettingsService.GetFieldsByCategory(sr.FieldCategory);
                result.Data = root;
                result.StatusCode = Models.MessageCodeEnum.Success;
                result.Info = "";
                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
