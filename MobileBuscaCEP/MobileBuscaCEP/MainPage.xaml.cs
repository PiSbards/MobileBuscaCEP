using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileBuscaCEP.Servico;
using MobileBuscaCEP.Servico.Modelo;

namespace MobileBuscaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btCEP.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null )
                    {
                        lblResultado.Text = string.Format("Endereço: {2},{3},{0} {1}", end.localidade,end.uf,end.logradouro,end.bairro);
                        CEP.Text = "";
                    }
                    else
                    {
                        DisplayAlert("Erro","O CEP" +cep+ "não foi encontrado!","OK");
                    }
                }
                catch (Exception er)
                {
                    DisplayAlert("Erro Crítico!",er.Message, "OK");
                }
            }
        }
        private bool isValidCep(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("Error", "CEP inválido! O CEP contém apenas 8 números.","OK");
                valido = false;
            }
            int NovoCep = 0;
            if(!int.TryParse(cep,out NovoCep))
            {
                DisplayAlert("Erro", "O CEP contém apenas números", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
