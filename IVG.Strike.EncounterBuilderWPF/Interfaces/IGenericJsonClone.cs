using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVG.Strike.EncounterBuilderWPF.Interfaces
{
    interface IGenericJsonClone<T>
    {
        T Clone();
    }
}
