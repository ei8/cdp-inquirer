using ei8.Cortex.Diary.Plugins.Inquirer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ei8.Cortex.Diary.Plugins.Inquirer
{
    internal static class ExtensionMethods
    {
        internal static async Task LoadAsync(this List<ExternalReferenceViewModel> value)
        {
            foreach (var f in value)
                await f.LoadAsync();
        }
    }
}
