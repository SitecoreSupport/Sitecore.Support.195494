using Sitecore.Diagnostics;
using Sitecore.EmailCampaign.Server.Contexts;
using Sitecore.EmailCampaign.Server.Responses;
using Sitecore.ExM.Framework.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Modules.EmailCampaign;
using Sitecore.Modules.EmailCampaign.Core;
using Sitecore.Modules.EmailCampaign.RecipientCollections;
using Sitecore.Services.Core;
using Sitecore.Web;
using System;
using System.Web.Http;

namespace Sitecore.Support.EmailCampaign.Server.Controllers.DefaultSettings
{
  [ServicesController("EXM.LoadDefaultSettingsEx")]
  public class LoadDefaultSettingsExController : Sitecore.EmailCampaign.Server.Controllers.DefaultSettings.LoadDefaultSettingsController
  {
    protected readonly Factory factory;

    protected readonly ILogger logger;

    public LoadDefaultSettingsExController() : this(Factory.Instance, Logger.Instance)
    {
    }
    public LoadDefaultSettingsExController(Factory factory, ILogger logger) : base(factory, logger)
    {
      this.factory = factory;
      this.logger = logger;
    }

    [ActionName("LoadDefaultSettingsLang")]
    public Response LoadDefaultSettingsLang(StringContext data)
    {
      Assert.ArgumentNotNull(data, "data");
      Sitecore.Support.EmailCampaign.Server.Responses.DefaultSettingsResponse defaultSettingsResponse = new Sitecore.Support.EmailCampaign.Server.Responses.DefaultSettingsResponse
      {
        Error = false,
        ErrorMessage = string.Empty
      };
      try
      {
        Language lang = null;
        ManagerRoot managerRoot = null;
        if (string.IsNullOrEmpty(WebUtil.GetQueryString("la")) && !string.IsNullOrEmpty(Context.User.Profile.ContentLanguage))
        {
          lang = Language.Parse(Context.User.Profile.ContentLanguage);
          managerRoot = Factory.GetManagerRootFromItem(new ItemUtilExt().GetItem(Data.ID.Parse(data.Value), lang, true));
        }
        else
        {
          managerRoot = this.factory.GetManagerRoot(new Guid(data.Value));
        }

        RecipientCollection globalOptOutList = managerRoot.GetGlobalOptOutList();
        defaultSettingsResponse.BaseUrl = managerRoot.Settings.BaseURL;
        defaultSettingsResponse.PreviewBaseUrl = managerRoot.Settings.PreviewBaseURL;
        defaultSettingsResponse.FromAddress = managerRoot.Settings.FromAddress;
        defaultSettingsResponse.FromName = managerRoot.Settings.FromName;
        defaultSettingsResponse.ReplyTo = managerRoot.Settings.ReplyTo;
        defaultSettingsResponse.GlobalOptOutList = globalOptOutList.Name;
        defaultSettingsResponse.GlobalOptOutListId = globalOptOutList.Id;
        defaultSettingsResponse.Language = managerRoot.InnerItem.Language.Name;
      }
      catch (Exception ex)
      {
        this.logger.LogError(ex.Message, ex);
        defaultSettingsResponse.Error = true;
        defaultSettingsResponse.ErrorMessage = ex.Message;
      }
      return defaultSettingsResponse;
    }

  }

  
}