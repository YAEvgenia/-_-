using CadastralManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastralManagement.Data.Interfaces
{
    interface ILandRegistry
    {
        IEnumerable<LandRegistry> AllLandRegistry { get;  }

        LandRegistry getLandRegistryById(int LandId);

        IEnumerable<LandRegistry> getLandRegistryByPassport { get;  }

    }
}
