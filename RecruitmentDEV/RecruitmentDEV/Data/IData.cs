using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentDEV.Data
{
    interface IData
    {
        /// <summary>
        /// Specifies test data parsing from any source
        /// </summary>
        /// <param name="datasource">API path / filepath to JSON file or other</param>
        /// <returns></returns>
        Data GetData(string datasource);
    }
}
