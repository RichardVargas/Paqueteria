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
    class pCancion
    {
        public string action { get; set; }
        public pCancion()
        {
            action = "Motos";
        }
    };

    class resultsCanciones
    {
        public int idMoto{ get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Costo { get; set; }
        public string Existencia { get; set; }
        public override string ToString()
        {
            return String.Format("{0} : {1}  :{2}   :{3} ",Nombre,Marca,Costo,Existencia);
        }
    };
}