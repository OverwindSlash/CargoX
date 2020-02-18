using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using Pensees.CargoX.Repository.Faces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class FaceRepository : CargoXRepositoryBase<Face, long>, IFaceRepository
    {
        public FaceRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        protected override List<ICriterion<Face>> ConvertToCriteria(Dictionary<string, string> parameters)
        {
            List<ICriterion<Face>> queryCriteria = new List<ICriterion<Face>>();

            foreach (var param in parameters)
            {
                switch (param.Key.ToLower())
                {
                    case "faceid":
                        queryCriteria.Add(new FaceIdCriterion(param.Value));
                        break;

                    default:
                        break;
                }
            }

            return queryCriteria;
        }
    }
}
