using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakealotApi.Models
{
    public class Takealot
    {
        [JsonProperty("response")]
        public TakealotItem Response { get; set; }
    }
}
