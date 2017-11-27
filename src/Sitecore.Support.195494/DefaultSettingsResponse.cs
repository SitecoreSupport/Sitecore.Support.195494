using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.EmailCampaign.Server.Responses
{
  public class DefaultSettingsResponse: Sitecore.EmailCampaign.Server.Responses.DefaultSettingsResponse
  {
    [JsonProperty("language")]
    public string Language { get; set; }
  }
}