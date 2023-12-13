using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ei8.Cortex.Diary.Plugins.Inquirer.ViewModels
{
    public class InquiryViewModel
    {
        public InquiryViewModel()
        {
            this.AvatarUrl = string.Empty;
            this.Filters = new List<ExternalReferenceViewModel>();
            this.Queries = new List<QueryViewModel>();
        }

        public string AvatarUrl { get; set; }

        public List<ExternalReferenceViewModel> Filters { get; set; }

        public List<QueryViewModel> Queries { get; set; }

        public async Task LoadFiltersAsync()
        {
            await this.Filters.LoadAsync();

            foreach (var q in this.Queries)
                await q.LoadFiltersAsync();
        }

        public async Task LoadResultsAsync()
        {
            foreach (var q in this.Queries)
                await q.LoadResultsAsync(this.AvatarUrl, this.Filters);
        }
    }
}
