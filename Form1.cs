using System;                              

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WebSocket4Net;
using Newtonsoft.Json.Linq;
using System.Media;
using System.IO;
using System.Net;
using System.Net.Configuration;
using System.Text.RegularExpressions;

namespace BOTAbritradorPorPlazoIOL
{
    public partial class frmBOT : Form
    {
        const string sURL = "https://api.invertironline.com";
        string bearer;
        string refresh;

        double umbralBonos;
        double umbralAcciones;

        DateTime expires;
        List<KeyValuePair<string, string>> tickers;

        string recordSeparator = "";
        WebSocket websocket;


        public frmBOT()
        {
            InitializeComponent();
        }

        private void frmBOT_Load(object sender, EventArgs e)
        {
            FillTickers();
            IniciarForm();

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = (SettingsSection)config.GetSection("system.net/settings");
            settings.HttpWebRequest.UseUnsafeHeaderParsing = true;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("system.net/settings");
            try
            {
                txtUsuario.Text = ConfigurationManager.AppSettings["UsuarioIOL"];
                txtContraseña.Text = ConfigurationManager.AppSettings["ClaveIOL"];
            }
            catch (Exception ex)
            {
            }
            //Acciones al 5%: 0,7986; acciones al 3%: 0,56; Bonos al 5% 0.52; Bonos al 3%: 0,32
            umbralAcciones = 0.31;  //Establecer los umbrales de acuerdo a la comisión de cada uno.
            umbralBonos = 0.12;

        }
        private void FillTickers()
        {
            tickers = new List<KeyValuePair<string, string>>();


            //AddTicker("0", "CEDEARs");

            /*
            AddTicker("94694", "FB");
            AddTicker("66457", "GOOGL");
            AddTicker("87671", "HMY");
            AddTicker("94702", "PYPL");
            AddTicker("101554", "SPOT");
            AddTicker("99084", "TSM");
            AddTicker("94704", "TSLA");
            */
            //AddTicker("0", "Galpones");
            /*
            AddTicker("3445", "GGAL");
            AddTicker("1258", "TXAR");
            AddTicker("2846", "YPFD");
            */

            //Bonos
            //AddTicker("99925", "AL29");
            //AddTicker("99934", "AL29D");
            //AddTicker("99935", "AL29C");

            //AddTicker("0", "Bonos");
            //AddTicker("99919", "AL30");
            //AddTicker("99926", "AL30D");
            //AddTicker("99927", "AL30C");

            //AddTicker("99920", "AL35");
            //AddTicker("99928", "AL35D");
            //AddTicker("99929", "AL35C");

            //AddTicker("99921", "AE38");
            //AddTicker("99930", "AE38D");
            //AddTicker("99931", "AE38C");

            //AddTicker("99922", "AL41");
            //AddTicker("87456", "CO26");
            //AddTicker("33107", "CUAP");
            AddTicker("22585", "DICP");
            //AddTicker("22582", "PARP");

            //AddTicker("99952", "GD29");
            //AddTicker("99957", "GD29D");
            //AddTicker("99956", "GD29C");

            //AddTicker("99943", "GD30");
            //AddTicker("99958", "GD30D");
            //AddTicker("99963", "GD30C");
            
            //AddTicker("99944", "GD35");
            //AddTicker("99959", "GD35D");
            //AddTicker("99965", "GD35C");

            //AddTicker("99949", "GD38");
            //AddTicker("99951", "GD41");
            //AddTicker("99953", "GD46");

            //AddTicker("22582", "PARP");
            AddTicker("92379", "PBA25");
            //AddTicker("88518", "PBY22");
            //AddTicker("21957", "PR13");
            //AddTicker("66447", "PR15");
            //AddTicker("100429", "TV22");
            //AddTicker("97866", "TX23");
            //AddTicker("97867", "TX24");
            AddTicker("99923", "TX26");
            AddTicker("99924", "TX28");
            //AddTicker("87055", "TO23");
            //AddTicker("102978", "T2X4");

            //Letras
            //AddTicker("101675", "S30N2");

            //Acciones
            /*
            AddTicker("17388", "ALUA");
            AddTicker("1320", "BBAR");
            AddTicker("444", "BMA");
            AddTicker("88356", "BYMA");
            AddTicker("3445", "GGAL");
            AddTicker("1978", "PAMP");
            AddTicker("83755", "SUPV");
            AddTicker("1258", "TXAR");
            AddTicker("2846", "YPFD");
            */

            //CEDEARs nuevos
            /*
            AddTicker("101533", "ABBV");
            AddTicker("101536", "AVGO");
            AddTicker("101535", "BIOX");
            AddTicker("432", "BRKB");
            AddTicker("101537", "CAAP");
            AddTicker("100442", "CS");
            AddTicker("101538", "DOCU");
            {AddTicker("101539", "ETSY");
            AddTicker("101542", "MA");
            AddTicker("101543", "PAAS");
            AddTicker("101544", "PSX");
            AddTicker("101553", "SHOP");
            AddTicker("101555", "SNOW");
            AddTicker("101554", "SPOT");
            AddTicker("101552", "SQ");
            AddTicker("101547", "UNH");
            AddTicker("101545", "UNP");
            AddTicker("101549", "WBA");
            AddTicker("101550", "ZM");
            */

            //CEDEARs viejos
            //AddTicker("94694", "FB");
            //AddTicker("66459", "MELI");
            //AddTicker("1673", "MMM");
            //AddTicker("66449", "X");
            /*
            AddTicker("66460", "AAPL");
            AddTicker("96128", "ABEV");
            AddTicker("15", "ABT");
            AddTicker("94697", "ADBE");
            AddTicker("94733", "ADGO");
            AddTicker("52", "AIG");
            AddTicker("94722", "AMD");
            AddTicker("104", "AMGN");
            AddTicker("42529", "AMX"); ;
            AddTicker("94695", "AMZN");
            AddTicker("94731", "ARCO");
            AddTicker("80105", "AUY");
            AddTicker("156", "AXP");
            AddTicker("87759", "AZN");
            AddTicker("168", "BA");
            AddTicker("47913", "BA.C");
            AddTicker("1320", "BABA");
            AddTicker("66456", "BB");
            AddTicker("76498", "BBD");
            AddTicker("28496", "BBV");
            AddTicker("28115", "BCS");
            AddTicker("76503", "BHP");
            AddTicker("95597", "BIDU");
            AddTicker("94698", "BIIB");
            AddTicker("87584", "BNG");
            AddTicker("28089", "BP");
            AddTicker("96136", "BRFS");
            AddTicker("77834", "BSBR");
            AddTicker("28753", "C");
            AddTicker("543", "CAH");
            AddTicker("559", "CAT");
            //AddTicker("84068", "CDE");
            //AddTicker("28587", "CHL");
            AddTicker("909", "CL");
            AddTicker("1032", "COST");
            AddTicker("94703", "CRM");
            AddTicker("1102", "CSCO");
            AddTicker("29423", "CVX");
            AddTicker("28497", "CX");
            AddTicker("1177", "DE");
            AddTicker("94732", "DESP");
            AddTicker("37982", "DISN");
            AddTicker("66458", "EBAY");
            AddTicker("1272", "ERIC");
            AddTicker("96140", "ERJ");
            AddTicker("94694", "FB");
            AddTicker("66450", "FCX");
            AddTicker("1295", "FDX");
            AddTicker("28603", "FMX");
            AddTicker("66453", "FSLR");
            AddTicker("1372", "GE");
            AddTicker("96121", "GFI");
            AddTicker("96135", "GGB");
            AddTicker("94721", "GILD");
            AddTicker("94734", "GLNT");
            AddTicker("75504", "GOLD");
            AddTicker("66457", "GOOGL");
            AddTicker("94729", "GS");
            AddTicker("1427", "HD");
            AddTicker("87671", "HMY");
            AddTicker("1459", "HPQ");
            AddTicker("29314", "HSBC");
            AddTicker("1462", "IBM");
            AddTicker("1488", "INTC");
            AddTicker("96139", "ITUB");
            AddTicker("96131", "JD");
            AddTicker("1520", "JNJ");
            AddTicker("1524", "JPM");
            AddTicker("1533", "KO");
            AddTicker("1641", "MCD");
            AddTicker("66459", "MELI");
            AddTicker("1673", "MMM");
            AddTicker("1676", "MO");
            AddTicker("1694", "MRK");
            AddTicker("1701", "MSFT");
            AddTicker("94693", "NFLX");
            AddTicker("1718", "NKE");
            AddTicker("1721", "NOKA");
            AddTicker("94696", "NVDA");
            AddTicker("87319", "OGZD");
            AddTicker("28915", "ORAN");
            AddTicker("1940", "ORCL");
            AddTicker("96236", "PBR");
            AddTicker("2116", "PEP");
            AddTicker("2171", "PFE");
            AddTicker("2177", "PG");
            */
            //AddTicker("94702", "PYPL");
            /*
            AddTicker("2388", "QCOM");
            AddTicker("87360", "RDS");
            AddTicker("66781", "RIO");
            AddTicker("2798", "RTX");
            AddTicker("29406", "SAP");
            AddTicker("2455", "SBUX");
            AddTicker("96146", "SID");
            AddTicker("2482", "SLB");
            AddTicker("94723", "SNAP");
            AddTicker("29445", "SONY");
            AddTicker("2520", "T");
            AddTicker("96106", "TEN");
            AddTicker("28986", "TOT");
            AddTicker("94707", "TRIP");
            AddTicker("99084", "TSM");
            AddTicker("94704", "TSLA");
            AddTicker("94705", "TWTR");
            AddTicker("2783", "TXN");
            AddTicker("2780", "TXR");
            AddTicker("96141", "UGP");
            AddTicker("99146", "UL");
            */
            //AddTicker("94730", "V");
            /*
            AddTicker("38472", "VALE");
            AddTicker("96129", "VIV");
            AddTicker("2807", "VOD");
            AddTicker("94724", "VRSN");
            AddTicker("77694", "VZ");
            AddTicker("2820", "WFC");
            AddTicker("2827", "WMT");
            AddTicker("2834", "XOM");
            */


            //Galpones
            /*
            AddTicker("21520", "AUSO");
            AddTicker("302", "BHIP");
            AddTicker("34089", "BOLT");
            AddTicker("773", "CEPU");
            AddTicker("1087", "CRES");
            AddTicker("37158", "CTIO");
            AddTicker("89062", "CVH");
            AddTicker("34271", "EDN");
            AddTicker("95368", "GAMI");
            AddTicker("1515", "HARG");
            AddTicker("89736", "LOMA");
            AddTicker("1665", "MIRG");
            AddTicker("1850", "OEST");
            AddTicker("2437", "SAMI");
            AddTicker("2621", "TECO2");
            AddTicker("69332", "TGLT");
            AddTicker("33643", "TGNO4");
            AddTicker("2681", "TGSU2");
            AddTicker("2747", "TRAN");
            AddTicker("88875", "VALO");
            */
        }
        private void IniciarForm()
        {
            DoubleBuffered = true;
            CheckForIllegalCrossThreadCalls = false;

            txtStatus.Text = "Nada";

            grdPanel.Columns.Clear();
            grdPanel.Rows.Clear();
            grdPanel.Columns.Add("Ticker", "Ticker");
            grdPanel.Columns[0].Width = 60;
            grdPanel.Columns[0].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPanel.Columns.Add("Momento", "Momento");
            grdPanel.Columns[1].Width = 70;
            grdPanel.Columns[1].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPanel.Columns.Add("QCI", "QCI");
            grdPanel.Columns[2].Width = 70;
            grdPanel.Columns[2].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPanel.Columns.Add("PCI", "PCI");
            grdPanel.Columns[3].Width = 70;
            grdPanel.Columns[3].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPanel.Columns.Add("PV48", "PV48");
            grdPanel.Columns[4].Width = 70;
            grdPanel.Columns[4].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPanel.Columns.Add("QV48", "QV48");
            grdPanel.Columns[5].Width = 70;
            grdPanel.Columns[5].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdPanel.Columns.Add("Ratio", "Ratio");
            grdPanel.Columns[6].Width = 80;
            grdPanel.Columns[6].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach(KeyValuePair<string,string> ticker in tickers)
            {
                grdPanel.Rows.Add(ticker.Value);
            }

            for (double j=-0.4; j<=1;j=j+0.1)
            {
                cboUmbral.Items.Add(Math.Round(j,2));
            }
            cboUmbral.SelectedIndex=3;

        }
        private string GetTickerByCodigo(object Codigo)
        {
            KeyValuePair<string, string> ticker = tickers.Where(t => t.Key == Codigo.ToString()).FirstOrDefault();
            return ticker.Value;
        }

        private string GetCodigoByTicker(string Ticker)
        {
            KeyValuePair<string, string> ticker = tickers.Where(t => t.Value == Ticker).FirstOrDefault();
            return ticker.Key;
        }

        private void SuscribirWS()
        {
            int i = 0;
            foreach (KeyValuePair<string, string> ticker in tickers)
            {
                SuscribirDoble(ticker.Value, i);
                i += 2;
            }
        }

        private void SuscribirDoble(string papel, int id)
        {
            string t0 = id.ToString();
            string t1 = (id + 1).ToString();
            websocket.Send("{\"arguments\":[\"" + GetCodigoByTicker(papel) + "-1\"],\"invocationId\":\"" + t0 + "\",\"target\":\"JoinGroup\",\"type\":1}" + recordSeparator);
            websocket.Send("{\"arguments\":[\"" + GetCodigoByTicker(papel) + "-2\"],\"invocationId\":\"" + t1 + "\",\"target\":\"JoinGroup\",\"type\":1}" + recordSeparator);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            tmr.Start();
            Login();
        }

        private void Login()
        {
            try
            {
                if (expires == DateTime.MinValue)
                {
                    string postData = "username=" + txtUsuario.Text + "&password=" + txtContraseña.Text + "&grant_type=password";
                    string response;
                    response = GetResponsePOST(sURL + "/token", postData);
                    dynamic json = JObject.Parse(response);
                    bearer = "Bearer " + json.access_token;
                    expires = DateTime.Now.AddSeconds((double)json.expires_in);
                    refresh = json.refresh_token;
                    txtBearer.Text = json.access_token;
                    ToLog(bearer);
                }
                else
                {
                    if (DateTime.Now > expires)
                    {
                        string postData = "refresh_token=" + refresh + "&grant_type=refresh_token";
                        string response;
                        response = GetResponsePOST(sURL + "/token", postData);
                        if(response.Contains("Error") || response.Contains("excedi"))
                        {
                            ToLog(response);
                        }
                        else
                        { 
                        dynamic json = JObject.Parse(response);
                        bearer = "Bearer " + json.access_token;
                        expires = DateTime.Now.AddSeconds((double)json.expires_in);
                        refresh = json.refresh_token;
                        txtBearer.Text = json.access_token;
                        ToLog(bearer);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ToLog(e.Message);                
            }
        }

        private string GetResponseGET(string sURL, string sHeader)
        {
            WebRequest request = WebRequest.Create(sURL);
            request.Timeout = 10000;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", sHeader);

            try
            {
                WebResponse response = request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        private string GetResponsePOST(string sURL, string sData)
        {
            WebRequest request = WebRequest.Create(sURL);
            var data = Encoding.ASCII.GetBytes(sData);
            request.Timeout = 10000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = sData.Length;

            if (bearer != null)
            {
                request.Headers.Add("Authorization", bearer);
            }
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                WebResponse response = request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        private void FillGrid()
        {
            string response;
            dynamic cotizaciones;
            dynamic cotizacion;
            dynamic punta;

            double precio1;
            double precio2;
            double porcentual;

            string simbolo;
            string PIV;
            string QIV;
            string PIC;
            string QIC;
            string P48V;
            string Q48V;
            string P48C;
            string Q48C;

            for (int i=0; i<grdPanel.Rows.Count;i++)
            {
                grdPanel.ClearSelection();
                grdPanel.Rows[i].Selected = true;
                Application.DoEvents();

                simbolo = grdPanel.Rows[i].Cells[0].Value.ToString();
                response = GetResponseGET(sURL + "/api/v2/{Mercado}/Titulos/{Simbolo}/Cotizacion?mercado=bcba&simbolo=" + simbolo + "&model.simbolo=" + simbolo + "&model.mercado=bCBA&model.plazo=t0", bearer);
                if (response.Contains("Error"))
                {
                    ToLog(" Error:" + response);
                    grdPanel.Rows[i].Cells[2].Value = "Error CI";
                    grdPanel.Rows[i].Cells[3].Value = "";
                    grdPanel.Rows[i].Cells[4].Value = "";
                    grdPanel.Rows[i].Cells[5].Value = "";
                    grdPanel.Rows[i].Cells[6].Value = "";
                    Application.DoEvents();
                }
                else
                {
                    cotizaciones = JArray.Parse("[" + response + "]");
                    cotizacion = cotizaciones[0];

                    if (cotizacion.puntas.Count > 0)
                    {
                        punta = cotizacion.puntas[0];
                        precio1 = (double)punta.precioVenta;

                        PIV = punta.precioVenta;
                        QIV = punta.cantidadVenta;
                        PIC = punta.precioCompra;
                        QIC = punta.cantidadCompra;

                        if (precio1 > 0)
                        {
                            response = GetResponseGET(sURL + "/api/v2/{Mercado}/Titulos/{Simbolo}/Cotizacion?mercado=bcba&simbolo=" + simbolo + "&model.simbolo=" + simbolo + "&model.mercado=bCBA&model.plazo=t1", bearer);
                            if (response.Contains("Error"))
                            {
                                ToLog(" Error:" + response);
                                grdPanel.Rows[i].Cells[2].Value = "";
                                grdPanel.Rows[i].Cells[3].Value = "";
                                grdPanel.Rows[i].Cells[4].Value = "";
                                grdPanel.Rows[i].Cells[5].Value = "Error 48hs";
                                grdPanel.Rows[i].Cells[6].Value = "";
                                Application.DoEvents();
                            }
                            else
                            {
                                cotizaciones = JArray.Parse("[" + response + "]");
                                cotizacion = cotizaciones[0];
                                punta = cotizacion.puntas[0];
                                precio2 = (double)punta.precioCompra;
                                if (precio2 > 0)
                                {
                                    P48V = punta.precioVenta;
                                    Q48V = punta.cantidadVenta;
                                    P48C = punta.precioCompra;
                                    Q48C = punta.cantidadCompra;

                                    porcentual = Math.Round(100 - ((precio1 / precio2) * 100), 4);

                                    grdPanel.Rows[i].Cells[1].Value = DateTime.Now.ToLongTimeString();
                                    grdPanel.Rows[i].Cells[2].Value = QIV;
                                    grdPanel.Rows[i].Cells[3].Value = PIV.Replace(".",",");
                                    grdPanel.Rows[i].Cells[4].Value = P48C.Replace(".",",");
                                    grdPanel.Rows[i].Cells[5].Value = Q48C;
                                    grdPanel.Rows[i].Cells[6].Value = porcentual;
                                    refreshRatio(i);

                                }
                            }
                        }
                    }
                    else
                    {
                        ToLog(simbolo + " sin puntas en inmediato");
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Login();
            FillGrid();
        }

        private void btnWS_Click(object sender, EventArgs e)
        {
            Login();
            ConectarWS();
        }

        private void ConectarWS()
        {
            try
            {
                string tokenURL = "https://streaming-externo-v2.invertironline.com/api/Account/HubToken";
                
                //Esto dejó de funcionar en 2001 cuando agregaron el control AntiBOTs...
                //string sData = ObtenerTokenWS(txtUsuario.Text, txtContraseña.Text);
                //Así que no me quedó otra que Hardcodear el Token, el cual es siempre el mismo.
                string sData = "{id: '644657', hashKey: '3iefDRw/0xqD8DnZUR00j+0qCJFAgKD0dpSc/qzZA6Q='}";
                var Data = Encoding.ASCII.GetBytes(sData);

                WebRequest request = WebRequest.Create(tokenURL);
                request.Timeout = 10000;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = Data.Length;
                var stream = request.GetRequestStream();
                stream.Write(Data, 0, Data.Length);
                WebResponse response = request.GetResponse();
                string respuesta = new StreamReader(response.GetResponseStream()).ReadToEnd();

                dynamic json = JObject.Parse(respuesta);
                string tokenWS = json.token;
                string expiracionWS = json.expiration;

                List<KeyValuePair<string, string>> lstHeaders = new List<KeyValuePair<string, string>>();

                websocket = new WebSocket("wss://streaming-externo-v2.invertironline.com/PuntaHub?access_token=" + tokenWS, "", null, lstHeaders,
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Safari/537.36", "https://www.invertironline.com",
                    WebSocketVersion.Rfc6455, null, System.Security.Authentication.SslProtocols.Tls12, 0);
                websocket.EnableAutoSendPing = true;
                websocket.NoDelay = true;

                websocket.Opened += new EventHandler(websocket_Opened);
                websocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(websocket_Error);
                websocket.Closed += Websocket_Closed;
                websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
                ToLog("Abriendo WS");
                websocket.Open();
                for (int i = 3; i > 0; i--)
                {
                    var t = Task.Delay(1000);
                    t.Wait();
                    ToLog("Suscripción de WS en " + (i).ToString());
                }
                SuscribirWS();
            }
            catch(Exception e)
            {

            }

        }
        
        private void Websocket_Closed(object sender, EventArgs e)
        {
            ToLog("Websocket CERRADO: " + e.ToString());
            ConectarWS();
        }

        private void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            ToLog(" Error: " + e.Exception.Message);
            //IniciarForm();
            //FillTickers();
            //ConectarWS();
        }

        private void websocket_Opened(object sender, EventArgs e)
        {
            ToLog("WS abierto");
            websocket.Send(@"{""protocol"":""json"",""version"":1}" + recordSeparator);
        }
        private void websocket_MessageReceived(object sender, WebSocket4Net.MessageReceivedEventArgs e)
        {
            //ToLog(e.Message.ToString());
            string msg = e.Message.Replace(recordSeparator,"¬");
            Char sep = '¬';

            string[] mensajes = msg.Split(sep);

            for (int i=0; i<mensajes.Length-1;i++)
            {
                dynamic mensaje = JObject.Parse(mensajes[i]);

                if (mensajes[i] == "{}")
                {
                    ToLog("Handshake ok");
                }
                else

                {
                    if (mensaje.type.Value == 6)
                    {
                        //websocket.Send(@"{""type"":6}");
                    }
                    if (mensaje.type.Value == 1 && mensaje.target.Value == "SendNewPuntasAsync")    //puntas
                    {
                        string sTicker = GetTickerByCodigo(mensaje.arguments[0].idTitulo.Value);
                        if (sTicker != "Error")
                        {
                            if (mensaje.arguments[0].plazoOperatoria.Value == 2)
                            {
                                double Q48V = mensaje.arguments[0].ultimasPuntas[0].cantidadVenta.Value;
                                double P48V = mensaje.arguments[0].ultimasPuntas[0].precioVenta.Value;
                                for (int j = 0; j < grdPanel.Rows.Count; j++)
                                {
                                    if (grdPanel.Rows[j].Cells[0].Value.ToString() == sTicker)
                                    {
                                        if (Q48V==0)
                                        {
                                            grdPanel.Rows[j].Cells[4].Value = "";
                                            grdPanel.Rows[j].Cells[5].Value = "";
                                        }
                                        else
                                        {
                                            grdPanel.Rows[j].Cells[4].Value = P48V;
                                            grdPanel.Rows[j].Cells[5].Value = Q48V;
                                        }
                                        refreshRatio(j);
                                    }
                                }
                            }
                            if (mensaje.arguments[0].plazoOperatoria.Value == 1)
                            {
                                //ToLog(sTicker + ": " + mensaje.arguments[0].ultimasPuntas[0].cantidadVenta.Value);
                                double QIC = mensaje.arguments[0].ultimasPuntas[0].cantidadCompra.Value;
                                double PIC = mensaje.arguments[0].ultimasPuntas[0].precioCompra.Value;
                                for (int j = 0; j < grdPanel.Rows.Count; j++)
                                {
                                    if (grdPanel.Rows[j].Cells[0].Value.ToString() == sTicker)
                                    {
                                        if (QIC==0)
                                        {
                                            grdPanel.Rows[j].Cells[2].Value = "";
                                            grdPanel.Rows[j].Cells[3].Value = "";
                                        }
                                        else
                                        {
                                            grdPanel.Rows[j].Cells[2].Value = QIC;
                                            grdPanel.Rows[j].Cells[3].Value = PIC;
                                        }
                                        refreshRatio(j);
                                    }
                                }
                            }
                        }
                        //ToLog(mensaje.root);
                    }
                }
            }
        }

        private void refreshRatio(int i)
        {
            Boolean esBono = false;
            string PIC = "";
            string P48V = "";
            string QIC = "";
            string Q48V = "";
            int Q;
            string simbolo = grdPanel.Rows[i].Cells[0].Value.ToString();
            grdPanel.ClearSelection();
            grdPanel.Rows[i].Cells[1].Value = DateTime.Now.ToLongTimeString();
            if (chkFollow.Checked)
            {
                grdPanel.CurrentCell = grdPanel.Rows[i].Cells[1];
            }
            grdPanel.Rows[i].Selected = true;
            Application.DoEvents();
            if (grdPanel.Rows[i].Cells[3].Value!=null)
            {
                PIC = grdPanel.Rows[i].Cells[3].Value.ToString();
                QIC = grdPanel.Rows[i].Cells[2].Value.ToString();
            }
            if (grdPanel.Rows[i].Cells[4].Value!=null)
            {
                P48V = grdPanel.Rows[i].Cells[4].Value.ToString();
                Q48V = grdPanel.Rows[i].Cells[5].Value.ToString();
            }
            if (PIC=="" || P48V=="")
            {
                grdPanel.Rows[i].Cells[6].Value = "";
            }
            else if (PIC!="" && P48V!="")
            {
                if (simbolo == "AL30" || simbolo == "AL29" || simbolo == "AL35" || simbolo == "AE38" ||
                    simbolo == "AL41" || simbolo == "TO23" || simbolo == "PBA25" || simbolo == "CO26" ||
                    simbolo == "CUAP" || simbolo == "DICP" || simbolo == "GD29" || simbolo == "GD30" ||
                    simbolo == "GD35" || simbolo == "GD38" || simbolo == "GD41" || simbolo == "GD46" ||
                    simbolo == "PARP" || simbolo == "PR13" || simbolo == "AL30D" || simbolo == "GD30D" ||
                    simbolo == "T2X4" || simbolo == "TO21" || simbolo == "T2V1" || simbolo == "TX21" ||
                    simbolo == "TX22" || simbolo == "TX23" || simbolo == "TX24" || simbolo == "TX26" ||
                    simbolo == "TX28" )
                    
                    //Sí, lo sé. Muchos de estos bonos ya no existen más.
                {
                    esBono = true;
                }
                else
                {
                    esBono = false;
                }

                double porcentual=Math.Round(100 - (( Convert.ToDouble(P48V) / Convert.ToDouble(PIC)) * 100), 4);
                grdPanel.Rows[i].Cells[6].Value = porcentual;

                if (porcentual>0)
                {
                    grdPanel.Rows[i].Cells[6].Style.ForeColor = Color.DarkGreen;
                }
                else
                {
                    grdPanel.Rows[i].Cells[6].Style.ForeColor = Color.Red;
                }

                double limiteBonos = umbralBonos + double.Parse(cboUmbral.Text.Replace(".",","));
                double limiteAcciones = umbralAcciones + double.Parse(cboUmbral.Text.Replace(".",","));

                if (
                    (esBono && (porcentual > limiteBonos))
                    ||
                    (!esBono && (porcentual > limiteAcciones))
                   )
                {
                    ToLog("Arbitraje en " + simbolo + " ratio " + porcentual.ToString());
                    if (chkBeep.Checked)
                    {
                        SystemSounds.Beep.Play();
                    }
                    grdPanel.Rows[i].Cells[6].Style.ForeColor = Color.DarkSlateBlue;
                }
                else
                {
                    //grdPanel.Rows[i].Cells[6].Style.ForeColor = Color.Red;
                }
                Application.DoEvents();
            }
        }
        private string GetEstadoOperacion(string idoperacion)
        {
            string response;
            response = GetResponseGET(sURL + "/api/v2/operaciones/" + idoperacion, bearer);
            if (response.Contains("Error") || response.Contains("Se exced"))
            {
                return "Error";
            }
            else
            {
                dynamic json = JObject.Parse(response);
                return json.estadoActual.Value;
            }
        }

        private void ToLog(string s)
        {
            lbLog.Items.Add(DateTime.Now.ToLongTimeString() + ':' + s);
            lbLog.SelectedIndex = lbLog.Items.Count - 1;
        }

        private void AddTicker(string Codigo, string Ticker)
        {
            tickers.Add(new KeyValuePair<string, string>(Codigo, Ticker));
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (txtUsuario.Text != string.Empty && txtContraseña.Text!=string.Empty)
            {
                Login();
            }
        }

        private void MiActivo_StopLoss(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            IniciarForm();
            FillTickers();
        }

        private string ObtenerTokenWS(string usuario, string clave)
        {

            string body;
            string TokenHeader;
            string TokenForm;
            string URL;
            string cookies;

            WebRequest xhr;
            HttpWebRequest hwr;
            WebResponse response;
            URL = "https://micuenta.invertironline.com/ingresar";

            xhr = WebRequest.CreateHttp(URL);
            xhr.Timeout = 5000;
            xhr.Method = "GET";
            cookies = "anonymous=true; intencionApertura=0; i18n.langtag=es-AR; isMobile=0";
            xhr.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            xhr.Headers.Add("Accept-Encoding", "deflate");
            xhr.Headers.Add("DNT", "1");
            xhr.Headers.Add("Cookie", cookies);
            xhr.Headers.Add("Upgrade-Insecure-Requests", "1");
            xhr.Headers.Add("Cache-Control", "max-age=0");
            response = xhr.GetResponse();


            hwr = (HttpWebRequest)WebRequest.CreateHttp(URL);
            hwr.Timeout = 5000;
            hwr.Method = "GET";
            hwr.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            hwr.Headers.Add("Accept-Encoding", "deflate");
            hwr.Headers.Add("DNT", "1");
            hwr.Headers.Add("Upgrade-Insecure-Requests", "1");
            hwr.Headers.Add("Cache-Control", "max-age=0");
            response = hwr.GetResponse();



            TokenHeader = StringBetween(response.Headers.Get("Set-Cookie"), "__RequestVerificationToken=", ";");
            TokenForm= StringBetween(new StreamReader(response.GetResponseStream()).ReadToEnd(), @"<input name=""__RequestVerificationToken"" type=""hidden"" value=""", @""" />");

            //string aux = response.Headers.Get("Set-Cookie");


            //cookies = response.Headers.Get("Set-Cookie");
            //RefrescarCookies(ref cookies, response.Headers.Get("Set-Cookie"));
            //cookies = GetCookies(response.Headers.ToString(), cookies);

            URL = "https://micuenta.invertironline.com/Ingresar";
            body = "__RequestVerificationToken=" + TokenForm;
            body = body + "&UrlRedireccion=&Usuario=" + usuario;
            body = body + "&Password=" + clave;
            hwr = WebRequest.CreateHttp(URL);
            hwr.Method = "POST";
            hwr.Host = "micuenta.invertironline.com";
            hwr.ContentType = "application/x-www-form-urlencoded";
            hwr.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            hwr.Referer = "https://micuenta.invertironline.com/Ingresar";
            hwr.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            hwr.Headers.Add("Accept-Encoding", "deflate");
            hwr.Headers.Add("DNT", "1");
            //hwr.Headers.Add("Cookie", cookies);
            hwr.Headers.Add("Upgrade-Insecure-Requests", "1");
            hwr.Headers.Add("Cache-Control", "no-cache");
            hwr.AllowAutoRedirect = false;

            hwr.ContentLength = body.Length;
            byte[] data = Encoding.ASCII.GetBytes(body);
            Stream stream = hwr.GetRequestStream();
            stream.Write(data, 0, data.Length);

            response = hwr.GetResponse();
            string dafcms = StringBetween(response.Headers.Get("Set-Cookie"), "5dafCMS575d0c=", ";");
            string sidglobal = StringBetween(response.Headers.Get("Set-Cookie"), "__sidglobal=", ";");
            //cookies = response.Headers.Get("Set-Cookie");


            URL = "https://iol.invertironline.com/MiCuenta/MiPortafolio";
            hwr = WebRequest.CreateHttp(URL);
            hwr.Method = "GET";
            hwr.Host = "www.invertironline.com";
            hwr.Referer = "https://iol.invertironline.com/MiCuenta/EstadoCuenta";
            hwr.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            hwr.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            hwr.Headers.Add("Accept-Encoding", "deflate");
            hwr.Headers.Add("DNT", "1");
            hwr.Headers.Add("Upgrade-Insecure-Requests", "1");
            hwr.Headers.Add("Cache-Control", "no-cache");
            //hwr.Headers.Add("Cookie", "anonymous=true; intencionApertura=0; i18n.langtag=es-AR; isMobile=0; __RequestVerificationToken=" + TokenHeader + "; __sidglobal=" + sidglobal + "; 5dafCMS575d0c=" + dafcms);
            //hwr.Headers.Add("Cookie", cookies);
            response = hwr.GetResponse();
            string resp = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return StringBetween(resp, "clientModel = Object.freeze(", ");");
            //El crédito por esta función es de @MarceloColom.
        }


        public string StringBetween(string Qry, string FTag, string STag)
        {
            string StringBetweenRet = default;
            int L;
            L = Qry.IndexOf(FTag) + FTag.Length;
            StringBetweenRet = Qry.Substring(L, Qry.IndexOf(STag, L) - L);
            return StringBetweenRet;
            //El crédito por esta función es de @MarceloColom.
        }


        public string GetCookies(string headers, string cookies)
        {
            Char sep = ';';

            string[] OldCookies = cookies.Split(sep);
            headers = headers.Replace(System.Environment.NewLine, "");
            cookies = StringBetweenPlus(headers, "Set-Cookie:", ";");
            int i = 0;
            while (i<=OldCookies.GetUpperBound(0))
            {
                char igual = '=';
                string[] OneCookie = OldCookies[i].Split(igual);
                /*
                if (cookies.IndexOf(compar)="0")
                {

                }
                */
                i++;
            }
            /*

            While i <= UBound(OldCookies)
                OneCookie = Split(OldCookies(i), "=")
                If InStr(cookies, Trim(OneCookie(0))) = 0 Then
                    cookies = cookies & ";" & OldCookies(i)
                End If
                i = i + 1
            Wend
            */
            return cookies;

        }


        public string StringBetweenPlus(string Qry, string FTag, string STag)
        {
            string StringBetweenPlusRet = default;
            int m = 1;
            int L;
            L = Qry.IndexOf(FTag);
            if (L <= 0) { return default; }
            L = L + FTag.Length;
            m = Qry.IndexOf(STag, L);
            if (m <= L) { return default; }

            StringBetweenPlusRet = StringBetweenPlusRet + Qry.Substring(L, m - L);
            while (true)
            {
                L = Qry.IndexOf(FTag, m);
                if (L<=0) { return default; }
                L = L + FTag.Length;
                m = Qry.IndexOf(STag, L);
                if (m <= L) { return default; }
                StringBetweenPlusRet = StringBetweenPlusRet + ";" + Qry.Substring(L, m - L);
            }
            return StringBetweenPlusRet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            string validez = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "T17:59:59.000Z";
            string postData = "mercado=bCBA&simbolo=AL30D&cantidad=1&precio=40&validez=" + validez + "&plazo=t0";
            string response;
            response = GetResponsePOST(sURL + "/api/v2/operar/Comprar", postData);
            */


        }
    }
}