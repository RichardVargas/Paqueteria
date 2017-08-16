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

namespace WebServiceRES
{
    class pGenero
    {

        public string action { get; set; }
        public string idMoto { get; set; }
        public string idCliente { get; set; }



        public pGenero(string idMotos, string idClientes )
        {
            action = "venta";
            idMoto = idMotos;
            idCliente = idClientes;
        }
    };

    
}