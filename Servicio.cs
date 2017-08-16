using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Net;
using System.IO;

namespace WebServiceRES
{
    class Servicio
    {
        private string url { get; set; }

        private HttpWebRequest httpRequest { get; set; }

        private HttpWebResponse httpResponse { get; set; }

        private StreamWriter streamWriter { get; set; }

        private StreamReader streamReader { get; set; }

        private string body { get; set; }

        private string results { get; set; }

        public Servicio()
        {
            //url = "http://localhost/json/";
            url = "http://172.20.10.10/Motos/";
            httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            streamWriter = new StreamWriter(httpRequest.GetRequestStream());
        }

        public string llamarServicio(string parametros)
        {
            //peticion al servivio
            body = parametros;
            streamWriter.InitializeLifetimeService();
            streamWriter.Write(body);
            streamWriter.Flush();
            //respuesta de web service
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                results = streamReader.ReadToEnd();
            }

            return results;
        }
    }
}