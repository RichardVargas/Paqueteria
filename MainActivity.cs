using Android.App;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using System.Collections.Generic;
using static Android.Resource;

namespace WebServiceRES
{
    [Activity(Label = "Web_Service", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnCanciones;
        Button btnArtistas;
        Button btnGeneros;
        ListView lbResultados;
        EditText edt1, edt2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            btnArtistas = FindViewById<Button>(Resource.Id.btnArtistas);
            btnCanciones = FindViewById<Button>(Resource.Id.btnCanciones);
            btnGeneros = FindViewById<Button>(Resource.Id.btnGenero);
            edt1 = FindViewById<EditText>(Resource.Id.editText1);
            edt2 = FindViewById<EditText>(Resource.Id.editText2);
            Button btnv = FindViewById<Button>(Resource.Id.btnV);

            lbResultados = FindViewById<ListView>(Resource.Id.lbResultado);

            btnArtistas.Click += BtnArtistas_Click;
            btnGeneros.Click += BtnGeneros_Click;
            btnCanciones.Click += BtnCanciones_Click;
            btnv.Click += Btnv_Click;
            
        }

        private void Btnv_Click(object sender, System.EventArgs e)
        {
            Servicio miServicio = new Servicio();
            pGenero parametros = new pGenero(edt1.Text, edt2.Text);
            string body = JsonConvert.SerializeObject(parametros);
            string resultadoSucioalv = miServicio.llamarServicio(body);
        }

        private void BtnCanciones_Click(object sender, System.EventArgs e)
        {
            List<string> lista = new List<string>();
            Servicio miServicio = new Servicio();
            pCancion parametros = new pCancion();
            string body = JsonConvert.SerializeObject(parametros);
            string resultadoSucioalv = miServicio.llamarServicio(body);
            string resultados = limpiar(resultadoSucioalv);
            var canciones = JsonConvert.DeserializeObject<List<resultsCanciones>>(resultados);
            int contador = 1;
            foreach (resultsCanciones cancion in canciones)
            {
                lista.Add(cancion.ToString());
                contador++;
            }
            lbResultados.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemActivated1, lista);
        }

        private void BtnGeneros_Click(object sender, System.EventArgs e)
        {
            
            Servicio miServicio = new Servicio();
            pGenero parametros = new pGenero(edt1.Text,edt2.Text);
            string body = JsonConvert.SerializeObject(parametros);
            string resultadoSucioalv = miServicio.llamarServicio(body);

        }

        private void BtnArtistas_Click(object sender, System.EventArgs e)
        {
            List<string> lista = new List<string>();
            Servicio miServicio = new Servicio();
            paArtistas parametros = new paArtistas();
            string body = JsonConvert.SerializeObject(parametros);
            string resultadoSucioalv = miServicio.llamarServicio(body);
           // string resultados = limpiar(resultadoSucio);
            var canciones = JsonConvert.DeserializeObject<List<resultArtistas>>(resultadoSucioalv);
            int contador = 1;           
            foreach (resultArtistas artista in canciones)
            {
                lista.Add(artista.artista);
                contador++;
            }
            lbResultados.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemActivated1, lista);
            //lbResultados.ItemClick += lbResultados.ItemClick;
        }
        private string limpiar(string strResSucio)
        {
            bool leer = false;
            string result = "";
            foreach (char letra in strResSucio)
            {
                if (letra == '[')
                    leer = true;
                if (leer)
                    result += letra;
            }
            return result;
        }
    }
}

