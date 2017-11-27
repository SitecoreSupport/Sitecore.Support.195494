using Sitecore.Diagnostics;
using Sitecore.EmailCampaign.Server.Contexts;
using Sitecore.EmailCampaign.Server.Responses;
using Sitecore.ExM.Framework.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Modules.EmailCampaign;
using Sitecore.Modules.EmailCampaign.Core;
using Sitecore.Modules.EmailCampaign.RecipientCollections;
using Sitecore.SecurityModel;
using Sitecore.Services.Core;
using Sitecore.Web;
using System;
using System.Web;
using System.Web.Http;

namespace Sitecore.Support
{
  [ServicesController("EXM.SaveDefaultSettingsEx")]
  public class SaveDefaultSettingsExController : Sitecore.EmailCampaign.Server.Controllers.DefaultSettings.SaveDefaultSettingsController
  {
    private readonly SecurityRights securityRights;

    private readonly Factory factory;

    private readonly ILogger logger;
    public SaveDefaultSettingsExController() : this(Factory.Instance, new SecurityRights(), Logger.Instance)
    {
    }

    public SaveDefaultSettingsExController(Factory factory, SecurityRights securityRights, ILogger logger) : base(factory, securityRights, logger)
    {
      this.factory = factory;
      this.securityRights = securityRights;
      this.logger = logger;
    }

    [ActionName("SaveDefaultSettingsLang")]
    public Response SaveDefaultSettingsLang(Sitecore.Support.EmailCampaign.Server.Contexts.DefaultSettingsContext data)
    {
      Assert.ArgumentNotNull(data, "requestArgs");
      Assert.ArgumentNotNull(this.securityRights, "securityRights");
      Assert.IsTrue(this.securityRights.IsAdministrator() || this.securityRights.IsEcmAdvancedUser(), "No permission to save the default settings.");
      BooleanResponse booleanResponse = new BooleanResponse
      {
        Value = false
      };
      try
      {
        using (new SecurityDisabler())
        {
          Language lang = null;
          ManagerRoot managerRoot = null;
          if (string.IsNullOrEmpty(WebUtil.GetQueryString("la")) && !string.IsNullOrEmpty(Context.User.Profile.ContentLanguage))
          {
            lang = Language.Parse(data.Language);
            managerRoot = Factory.GetManagerRootFromItem(new ItemUtilExt().GetItem(Data.ID.Parse(data.ManagerRootId), lang, true));
          }
          else
          {
            managerRoot = this.factory.GetManagerRoot(new Guid(data.ManagerRootId));
          }
          managerRoot.Settings.BeginEdit();
          managerRoot.Settings.BaseURL = data.BaseUrl;
          managerRoot.Settings.PreviewBaseURL = (data.PreviewBaseUrl ?? string.Empty);
          managerRoot.Settings.FromAddress = HttpUtility.HtmlDecode(data.FromAddress);
          managerRoot.Settings.ReplyTo = data.ReplyTo;
          managerRoot.Settings.FromName = data.FromName;
          managerRoot.SetGlobalOptOutListById(data.GlobalOptOutListId);
          managerRoot.Settings.EndEdit();
        }
        booleanResponse.Value = true;
      }
      catch (Exception ex)
      {
        this.logger.LogError(ex.Message, ex);
      }
      return booleanResponse;
    }
  }
}