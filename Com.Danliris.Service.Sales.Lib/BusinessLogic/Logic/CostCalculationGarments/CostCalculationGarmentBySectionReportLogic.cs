﻿using Com.Danliris.Service.Sales.Lib.Models.CostCalculationGarments;
using Com.Danliris.Service.Sales.Lib.Services;
using Com.Danliris.Service.Sales.Lib.Utilities.BaseClass;
using Com.Danliris.Service.Sales.Lib.ViewModels.CostCalculationGarment;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.BusinessLogic.Logic.CostCalculationGarments
{
    public class CostCalculationBySectionReportLogic : BaseMonitoringLogic<CostCalculationGarmentBySectionReportViewModel>
    {
        private IIdentityService identityService;
        private SalesDbContext dbContext;
        private DbSet<CostCalculationGarment> dbSet;

        public CostCalculationBySectionReportLogic(IIdentityService identityService, SalesDbContext dbContext)
        {
            this.identityService = identityService;
            this.dbContext = dbContext;
            dbSet = dbContext.Set<CostCalculationGarment>();
        }

        public override IQueryable<CostCalculationGarmentBySectionReportViewModel> GetQuery(string filter)
        {
            Dictionary<string, object> FilterDictionary = new Dictionary<string, object>(JsonConvert.DeserializeObject<Dictionary<string, object>>(filter), StringComparer.OrdinalIgnoreCase);

            IQueryable<CostCalculationGarment> Query = dbSet;

            try
            {
                var dateFrom = (DateTime) (FilterDictionary["dateFrom"]);
                var dateTo= (DateTime) (FilterDictionary["dateTo"]);

                Query = dbSet.Where(d => d.ConfirmDate >= dateFrom && 
                                         d.ConfirmDate <= dateTo
                );
            }
            catch (KeyNotFoundException e)
            {
                throw new Exception(e.Message);
            }

            if (FilterDictionary.TryGetValue("section", out object section))
            {
                Query = Query.Where(d => d.Section == section.ToString());
            }

            Query = Query.OrderBy(o => o.Section).ThenBy(o => o.BuyerBrandName);

            var newQ = (from a in Query
                    select new CostCalculationGarmentBySectionReportViewModel
                    {
                        RO_Number = a.RO_Number,
                        ConfirmDate = a.ConfirmDate,
                        DeliveryDate = a.DeliveryDate,
                        UnitName = a.UnitName,
                        Description = a.Description,
                        Section = a.Section,
                        SectionName = a.SectionName,
                        Article = a.Article,
                        BuyerCode = a.BuyerCode,
                        BuyerName = a.BuyerName,
                        BrandCode = a.BuyerBrandCode,
                        BrandName = a.BuyerBrandName,
                        Comodity = a.ComodityCode,
                        Quantity = a.Quantity,
                        ConfirmPrice = a.ConfirmPrice,
                        UOMUnit = a.UOMUnit,
                        Amount = a.Quantity * a.ConfirmPrice,
                    });

            return newQ;
        }
    }
}
