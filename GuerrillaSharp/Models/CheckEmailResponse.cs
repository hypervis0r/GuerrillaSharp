using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GuerrillaSharp.Models
{
    public class CheckEmailResponse
    {
        [JsonProperty("list")]
        public List<Email> Emails { get; set; }

        [JsonProperty("sid_token")]
        public string SidToken { get; set; }
    }
}
