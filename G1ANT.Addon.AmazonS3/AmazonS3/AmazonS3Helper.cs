using System;
using System.Collections.Generic;
using System.Linq;
using Amazon;

namespace G1ANT.Addon.AmazonS3
{
    public class AmazonS3Helper
    {

        public static List<String> GetRegionsList()
        {
            List<String> regions = new List<string>(10);
            List<RegionEndpoint> list = RegionEndpoint.EnumerableAllRegions.ToList();
            foreach (RegionEndpoint item in list)
            {
                regions.Add(item.SystemName);
            }
            return regions;
        }

    }
}
