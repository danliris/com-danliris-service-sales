﻿using Com.Danliris.Service.Sales.Lib.PDFTemplates;
using Com.Danliris.Service.Sales.Lib.ViewModels.FinishingPrinting;
using Com.Danliris.Service.Sales.Lib.ViewModels.IntegrationViewModel;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Com.Danliris.Sales.Test.PDFTemplates
{
    public class NewFinishingPrintingSalesContractPdfTemplateTest
    {
        [Fact]
        public void GeneratePdfTemplate_Return_Success()

        {
            NewFinishingPrintingSalesContractPdfTemplate pdf = new NewFinishingPrintingSalesContractPdfTemplate();
            FinishingPrintingSalesContractViewModel viewModel = new FinishingPrintingSalesContractViewModel()
            {
                SalesContractNo = "no",
                Buyer = new BuyerViewModel()
                {
                    Name = "name",
                    NIK = "nik",
                    Job = "job",
                    Address = "address",
                },
                Agent = new AgentViewModel()
                {
                    Id = 1,
                    Name = "name",
                    Code = "code",
                    Address = "address",
                    City = "city",
                    Country = "country",
                    Contact = "contact",
                },
                AutoIncrementNumber = 1,
                ProductType = new ProductTypeViewModel()
                {
                    Id = 1,
                    Code = "code",
                    Name = "name",
                    Remark = "remark",
                },
                AccountBank = new AccountBankViewModel()
                {
                    Id = 1,
                    Code = "code",
                    AccountName = "name",
                    AccountNumber = "number",
                    AccountCurrencyCode = "code",
                    AccountCurrencyId = "Id",
                    BankName = "name",
                    BankAddress = "Address",
                    SwiftCode = "code",
                    Currency = new CurrencyViewModel()
                    {
                        Id = 1,
                        Code = "code",
                        Symbol = "symbol",
                        Rate = 1,
                        Description = "description",
                    },
                },
                MaterialConstruction = new MaterialConstructionViewModel()
                {
                    Id = 1,
                    Code = "code",
                    Name = "name",
                    Remark = "remark",
                },
                Material = new ProductViewModel() //Material
                {
                    Code = "code",
                    Name = "name",
                    Price = 1,
                    Tags = "tag"
                },
                Code = "code",
                Commission = "comission",
                Commodity = new CommodityViewModel()
                {
                    Id = 1,
                    Code = "code",
                    Name = "name",
                    Type = "type",
                },
                CommodityDescription = "description",
                OrderQuantity = 1,
                Amount = 1,
                Packing = "packing",
                TermOfShipment = "shipment",
                TransportFee = "123",
                DeliveredTo = "deliveredto",
                DeliverySchedule = DateTimeOffset.Now,
                OrderType = new OrderTypeViewModel()
                {
                    Id = 1,
                    Code = "code",  
                    Name = "name",
                    Remark = "remark",
                },
                DispositionNumber = "disposition",
                MaterialWidth    = "width",
                PieceLength = "Length",
                PointLimit = 1,
                PointSystem = 1,
                Quality = new QualityViewModel()
                {
                    Id = 1,
                    Code = "code",
                    Name = "name",
                },
                ShipmentDescription = "description",
                ShippingQuantityTolerance = 1,
                TermOfPayment = new TermOfPaymentViewModel()
                {
                    Id = 1,
                    Code = "code",
                    Name = "name",
                    IsExport = true,
                },
                FromStock = true,
                UseIncomeTax = true,
                VatTax = new VatTaxViewModel()
                {
                    Id = "id",
                    Rate = 1,
                },
                UOM = new UomViewModel()
                {
                    Id = 1,
                    Unit = "unit"
                },
                YarnMaterial = new YarnMaterialViewModel()
                {
                    Id = 1,
                    Code = "code",
                    Name = "name",
                    Remark = "remark",
                },
                RemainingQuantity = 1,
                DesignMotive = new OrderTypeViewModel()
                {
                    Id = 1,
                    Code = "code",
                    Name = "name",
                    Remark = "remark",
                },
                Details = new List<FinishingPrintingSalesContractDetailViewModel>()
                
            };
            var result = pdf.GeneratedPdfTemplate(viewModel, 2);
            Assert.NotNull(result);
            Assert.IsType<MemoryStream>(result);
        }
    }
}
