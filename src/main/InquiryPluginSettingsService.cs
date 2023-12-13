using Microsoft.Extensions.Configuration;
using ei8.Cortex.Diary.Port.Adapter.UI.Views.Blazor.Common;

namespace ei8.Cortex.Diary.Plugins.Inquirer
{
    public class InquiryPluginSettingsService : IPluginSettingsService
    {
        private const int DefaultUpdateCheckInterval = 2000;

        public int UpdateCheckInterval => this.Configuration != null && int.TryParse(this.Configuration["UpdateCheckInterval"], out int uci) ? uci : InquiryPluginSettingsService.DefaultUpdateCheckInterval;

        public IConfiguration Configuration { get; set; }
    }
}
