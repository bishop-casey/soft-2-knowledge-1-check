using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2KnowledgeCheck1
{
    internal class ConstructAptHR : Construction
    {
        public List<Building> Buildings { get; } = new List<Building>();

        public void CreateApartment(Apartment apartment, HighRise highRise)
        {
            // Get materials
            var materialRepo = new MaterialsRepo();
            var materialsNeeded = materialRepo.GetMaterials();

            var permitRepo = new ZoningAndPermitRepo();

            var apartmentWasMade = ConstructBuilding<Apartment>(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());
            var highRiseWasMade = ConstructBuilding<HighRise>(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());

            if (apartmentWasMade)
            {
                Buildings.Add(apartment);
            }
            if (highRiseWasMade)
            {
                Buildings.Add(highRise);
            }
        }
    }
}
