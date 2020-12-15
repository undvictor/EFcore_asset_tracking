using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFassets.Domains
{
    public class Asset
    {

        //primary key for assets
        public int AssetId { get; set; }

        //foreign key for Office
        public Office Offices{ get; set; }

        // Name and model of Asset
        public string AssetName { get; set; }
        public string AssetModel { get; set; }
        //Dates for product purchase and expiration
        public DateTime purchaseDate { get; set; }
        public DateTime expirationDate { get; set; }

        //price
        public float price { get; set; }
        //AssetActive?       


        public Category CategoryObject { get; set; }

    }
}
