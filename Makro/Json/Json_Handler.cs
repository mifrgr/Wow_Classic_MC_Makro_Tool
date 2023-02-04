using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ServiceModel.Channels;
using Newtonsoft.Json.Linq;

namespace Makro.Json
{

    internal class Json_Handler
    {
        public string json_string;

        public bool Json_import()
        {
            Import_Json import_json = new Import_Json();
            import_json.ShowDialog();
            json_string = import_json.InputBox.Text;
            if(json_string != "")
                return true;
            else return false;
        }

        public List<Player> Json_read()
        {
            List<Player> players;
            try
            {
                JObject o = JObject.Parse(json_string);
                JArray a = (JArray)o["signups"];

                players = a.ToObject<List<Player>>();
            }

            catch(Exception e)
            {
                players = new List<Player>();
            }
            
            return players;
        }
    }

}
