using CadastralManagement.Data.Interfaces;
using CadastralManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastralManagement.Data.Mocks
{
    public class MockAutorizedUser : IAutorizedUser
    {
        public IEnumerable<AutorizedUser> AllAutorizedUser
        {
            get
            {
                return new List<AutorizedUser>
                {

                    new AutorizedUser{ passport="1234 900900", password="SW09", name="Misha"},
                    new AutorizedUser{ passport="1234 500500", password="SW10", name="Anna"}
                };
            }

        }

        public AutorizedUser getAutorizedUserByPassport(int userPassport)
        {
            throw new NotImplementedException();
        }
    }
}
