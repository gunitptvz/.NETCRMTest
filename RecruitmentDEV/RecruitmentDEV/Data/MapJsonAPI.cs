using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RecruitmentDEV.Data
{
    /// <summary>
    /// Contains members and functions to get Json files using API
    /// </summary>
    class MapJsonAPI : IData
    {
        /// <summary>
        /// Gets data from Json file
        /// </summary>
        /// <param name="datasource"></param>
        /// <returns></returns>
        public Data GetData(string datasource)
        {
            RestClient client = new RestClient(datasource);
            RestRequest request = new RestRequest(datasource, Method.GET);
            IRestResponse<Data> response = client.Execute<Data>(request);
            string a = response.Content;
            return response.Data;
        }
    }
}
