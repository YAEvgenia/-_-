using CadastralManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastralManagement.Data.Interfaces
{
    interface IAutorizedUser
    {
        IEnumerable<AutorizedUser> AllAutorizedUser { get; }

        AutorizedUser getAutorizedUserByPassport(int userPassport);

    }
}
