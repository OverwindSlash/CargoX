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
                    case "infokind":
                        queryCriteria.Add(new InfoKindCriterion(Convert.ToInt32(param.Value)));
                        break;
                    case "sourceid":
                        queryCriteria.Add(new SourceIdCriterion(param.Value));
                        break;
                    case "isvictim":
                        queryCriteria.Add(new IsVictimCriterion(Convert.ToInt32(param.Value)));
                        break;
                    case "isdetainees":
                        queryCriteria.Add(new IsDetaineesCriterion(Convert.ToInt32(param.Value)));
                        break;
                    case "issuspiciousperson":
                        queryCriteria.Add(new IsSuspiciousPersonCriterion(Convert.ToInt32(param.Value)));
                        break;
                    //case "feature":
                    //    queryCriteria.Add(new FeatureCriterion(param.Value));
                    //    break;
                    default:
                        break;
                }
            }

            return queryCriteria;
        }

        protected override List<ICriterion<Face>> ConvertToCriteria(Dictionary<string, Dictionary<string, string>> parameters)
        {
            List<ICriterion<Face>> queryCriteria = new List<ICriterion<Face>>();

            foreach (var param in parameters)
            {
                switch (param.Key.ToLower())
                {
                    case "faceid":
                        queryCriteria.Add(new FaceIdCriterion(param.Value));
                        break;
                    case "locationmarktime":
                        queryCriteria.Add(new LocationMarkTimeCriterion(param.Value));
                        break;
                    case "shottime":
                        queryCriteria.Add(new ShotTimeCriterion(param.Value));
                        break;
                    default:
                        break;
                }
            }

            return queryCriteria;
        }
    }
}
