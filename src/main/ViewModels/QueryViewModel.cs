using ei8.Cortex.Diary.Application.Neurons;
using ei8.Cortex.Diary.Port.Adapter.UI.ViewModels;
using ei8.Cortex.Library.Common;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ei8.Cortex.Diary.Plugins.Inquirer.ViewModels
{
    public class QueryViewModel
    {
        private INeuronQueryService neuronQueryService;

        public QueryViewModel(INeuronQueryService neuronQueryService)
        {
            this.neuronQueryService = neuronQueryService;

            this.Filters = new List<ExternalReferenceViewModel>();
            this.Results = new List<NeuronResultViewModel>();
        }

        public List<ExternalReferenceViewModel> Filters { get; set; }

        public List<NeuronResultViewModel> Results { get; set; }

        public async Task LoadFiltersAsync()
        {
            await this.Filters.LoadAsync();
        }

        public async Task LoadResultsAsync(string avatarUrl, IEnumerable<ExternalReferenceViewModel> generalFilters)
        {
            var allFilters = this.Filters.Concat(generalFilters);

            var items = (await this.neuronQueryService.GetNeurons(
                                    avatarUrl,
                                    new NeuronQuery()
                                    {
                                        PostsynapticExternalReferenceUrl = allFilters.Select(e => e.Url).ToArray()
                                    })
                                    ).Items;


            this.Results = new List<NeuronResultViewModel>(items.Select(n => new NeuronResultViewModel() { Neuron = n }));
        }
    }
}
