using Com.Danliris.Service.Sales.Lib.Models.Weaving;
using Com.Danliris.Service.Sales.Lib.Utilities;
using Com.Danliris.Service.Sales.Lib.Utilities.BaseClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.BusinessLogic.Logic.Weaving
{
    public class WeavingSalesContractLogic : BaseLogic<WeavingSalesContractModel>
    {
        public WeavingSalesContractLogic(IServiceProvider serviceProvider, SalesDbContext dbContext) : base(serviceProvider, dbContext)
        {
        }
        public override Tuple<List<WeavingSalesContractModel>, int, Dictionary<string, string>, List<string>> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            IQueryable<WeavingSalesContractModel> Query = this.DbSet;

            List<string> SearchAttributes = new List<string>()
            {
                "SalesContractNo","BuyerName"
            };

            Query = QueryHelper<WeavingSalesContractModel>.Search(Query, SearchAttributes, keyword);

            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            Query = QueryHelper<WeavingSalesContractModel>.Filter(Query, FilterDictionary);

            List<string> SelectedFields = new List<string>()
            {
                "Id", "SalesContractNo","Buyer","DeliverySchedule"
            };

            Query = Query
                .Select(field => new WeavingSalesContractModel
                {
                    Id = field.Id,
                    Code = field.Code,
                    SalesContractNo = field.SalesContractNo,
                    BuyerCode = field.BuyerCode,
                    BuyerId = field.BuyerId,
                    BuyerName = field.BuyerName,
                    BuyerType = field.BuyerType,
                    DeliverySchedule = field.DeliverySchedule,
                    LastModifiedUtc = field.LastModifiedUtc
                });

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(order);
            Query = QueryHelper<WeavingSalesContractModel>.Order(Query, OrderDictionary);

            List<WeavingSalesContractModel> Data = Query.Skip((page - 1) * size).Take(size).ToList();
            int TotalData = DbSet.Count();

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }
    }
}
