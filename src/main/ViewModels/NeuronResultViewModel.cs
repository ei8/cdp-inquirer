using ei8.Cortex.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ei8.Cortex.Diary.Plugins.Inquirer.ViewModels
{
    public class NeuronResultViewModel
    {
        public Neuron Neuron { get; set; }

        public string Tag => this.Neuron != null ? this.Neuron.Tag : string.Empty;

        public string StatusMessage
        {
            get
            {
                var result = string.Empty;
                if (this.Neuron != null)
                {
                    if (this.Neuron.Validation.RestrictionReasons.Any())
                        result = string.Join("; ", this.Neuron.Validation.RestrictionReasons.ToArray());
                }
                return result;
            }
        }
    }
}
