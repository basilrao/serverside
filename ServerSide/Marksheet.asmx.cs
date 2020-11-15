using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServerSide
{
    /// <summary>
    /// Summary description for Marksheet
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Marksheet : System.Web.Services.WebService
    {

        [WebMethod]
        public string CalculateData(List<string> name, List<int> marks)
        {
            int mx = marks[0];
            int mn = marks[0];
            int min = 0, max = 0, sum = marks[0];
            for (int i = 1; i < name.Count; i++)
            {
                if (marks[i] > mx)
                {
                    mx = marks[i];
                    max = i;
                }


                if (marks[i] < mn)
                {
                    mn = marks[i];
                    min = i;
                }
                sum += marks[i];
            }
            List<string> data = new List<string>();
            data.Add(name[max]);
            data.Add(marks[max].ToString());
            data.Add(name[min]);
            data.Add(marks[min].ToString());
            data.Add(((sum/name.Count+1)-1).ToString());

            return JsonConvert.SerializeObject(data);
        }
    }
}
