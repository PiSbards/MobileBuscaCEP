using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using MobileBuscaCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace MobileBuscaCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP (string cep)
        {
            string NovoEnderecoURL = string.Format (EnderecoURL, cep);
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
            if (end.cep == null) return null;
            return end;
        }
    }
}
