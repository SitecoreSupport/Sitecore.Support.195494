using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.EmailCampaign.Server.Contexts
{
  public class DefaultSettingsContext: Sitecore.EmailCampaign.Server.Contexts.DefaultSettingsContext
  {
    [JsonProperty("language")]
    public string Language { get; set; }
  }
}