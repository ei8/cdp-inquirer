using ei8.Cortex.Diary.Application.Neurons;
using ei8.Cortex.Diary.Port.Adapter.UI.Views.Common;
using ei8.Cortex.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ei8.Cortex.Diary.Plugins.Inquirer.ViewModels
{
    public class ExternalReferenceViewModel
    {
        private INeuronQueryService neuronQueryService;

        public ExternalReferenceViewModel(INeuronQueryService neuronQueryService)
        {
            this.neuronQueryService = neuronQueryService;
        }

        public string Url { get; set; }

        public string Tag { get => this.Neuron != null ? this.Neuron.Tag : string.Empty; }
        
        public Neuron Neuron { get; set; }

        public async Task LoadAsync()
        {
            var ns = (await this.neuronQueryService.SendQuery(
                        this.Url,
                        true
                    )).Items;
            this.Neuron = ns.SingleOrDefault();
        }
    }
}
