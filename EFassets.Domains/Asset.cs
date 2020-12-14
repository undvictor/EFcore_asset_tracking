using System;
using System.Collections.Generic;
using System.Text;

namespace EFassets.Domains
{
    public class Asset
    {
        //primary key for assets
        public int AssetId { get; set; }
        //foreign key for category
        public int categoryId;
        //foreign key for Office
        public int officeId;
        // Name and model of Asset
        public string AssetName { get; set; }
        public string AssetModel { get; set; }
        //Dates for product purchase and expiration
        public DateTime purchaseDate;
        public DateTime expirationDate;
        //price
        public float price;
        //AssetActive?
        public bool assetActive;   
    }
}
