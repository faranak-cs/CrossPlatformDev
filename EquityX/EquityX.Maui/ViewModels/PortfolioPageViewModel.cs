﻿using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels
{

    //static repo for mockups/fake data
    public static class PortfolioPageViewModel
    {
        //we need to create two lists: one for summary and
        //other will be refined based on first one and 
        //will be used for portfolio page and
        //first one for summary page

        public static List<Assets> _assets = new List<Assets>()
        {  new Assets {AssetId=0, Name="Google", Investment=400, Unit=1},
           new Assets {AssetId=1, Name="Google", Investment=400, Unit=1}
        };

        //this will be used for assets page
        public static List<Assets> _unique_assets = new List<Assets>()
        {
            new Assets {AssetId=0, Name="Google", Investment=800, Unit=2}
        };

        public static List<Assets> GetAssets() => _assets;
        public static List<Assets> GetUniqueAssets() => _unique_assets;

        public static double GetSum()
        {
            double sum = 0;
            foreach (var asset in _unique_assets)
            {
                sum = sum + asset.Investment;

            }
            return sum;
        }


        //will be used to display history of individual asset
        public static Assets GetAssetById(int assetId)
        {
            var asset = _unique_assets.FirstOrDefault(x => x.AssetId == assetId);

            if (asset != null)
            {
                return new Assets
                {
                    AssetId = asset.AssetId,
                    Name = asset.Name,
                    Investment = asset.Investment,
                    Unit = asset.Unit
                };
            }

            return null;
        }

        // GET ASSET BY NAME
        public static Assets GetAssetByName(string assetName)
        {
            var asset = _unique_assets.FirstOrDefault(x => x.Name == assetName);

            if (asset != null)
            {
                return new Assets
                {
                    AssetId = asset.AssetId,
                    Name = asset.Name,
                    Investment = asset.Investment,
                    Unit = asset.Unit
                };
            }

            return null;
        }

        public static void AddAsset(Assets asset)
        {
            //used for summary page

            asset.AssetId = (_assets.Max(x => x.AssetId)) + 1;
            _assets.Add(asset);


            //used for assets page
            var existingAsset = _unique_assets.FirstOrDefault(x => x.Name == asset.Name);
            if (existingAsset == null)
            {
                //update the id too and then add the asset
                asset.AssetId = (_unique_assets.Max(x => x.AssetId)) + 1;
                _unique_assets.Add(asset);
            }
            else
            {
                existingAsset.Investment += asset.Investment;
                existingAsset.Unit += asset.Unit;
            }
        }

        public static void RemoveAsset(int stockUnit, string assetName, double stockPrice)
        {
            var asset = _unique_assets.FirstOrDefault(x => x.Name == assetName);

            if (stockUnit == 1)
            {
                _unique_assets.Remove(asset);
            }
            else
            {
                asset.Unit -= stockUnit;
                // HOW TO DECREASE THE INVESTMENT
                asset.Investment -= stockPrice;
            }
        }
    }
}
