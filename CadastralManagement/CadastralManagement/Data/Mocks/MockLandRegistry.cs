using CadastralManagement.Data.Interfaces;
using CadastralManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastralManagement.Data.Mocks
{
    public class MockLandRegistry : ILandRegistry
    {
        public IEnumerable<LandRegistry> AllLandRegistry
        {
            

            get 
            {
                DateTime date = new DateTime(11, 12, 2003);
                DateTime date1 = new DateTime(14, 2, 2009);
                return new List<LandRegistry>
                {

                    new LandRegistry{area=2000, address="пр-т строителей 7г", approvalDate=date, passport="1010 980980", price=2300000, taxCoefficint=0.02 },
                    new LandRegistry{area=480, address="пр-т строителей 7б", approvalDate=date1, passport="1220 980980", price=390000, taxCoefficint=0.02 }
                };
            }
        }
        public IEnumerable<LandRegistry> getLandRegistryByPassport { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public LandRegistry getLandRegistryById(int LandId)
        {
            throw new NotImplementedException();
        }
    }
}
