using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace RecruitmentDEV.Data
{
    /// <summary>
    /// Contains members and functions to get Json files using API
    /// </summary>
    public class MapJsonAPI : IData
    {
        /// <summary>
        /// Gets data from Json file
        /// </summary>
        /// <param name="datasource"></param>
        /// <returns></returns>
        public DataModel GetData(string datasource)
        {
            DataModel result = new DataModel();

            RestClient client = new RestClient(datasource);
            RestRequest request = new RestRequest(datasource, Method.GET);
            IRestResponse response = client.Execute(request);
            result = JsonConvert.DeserializeObject<DataModel>(response.Content);

            return result;
        }
    }
}
