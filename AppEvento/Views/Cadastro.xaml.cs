using AppEvento.Models;
using System;
using Microsoft.Maui.Controls;

namespace AppEvento.Views;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();

        dtp_inicio.MinimumDate = DateTime.Now;
        dtp_inicio.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 2, DateTime.Now.Day);

        dtp_termino.MinimumDate = dtp_inicio.Date;
        dtp_termino.MaximumDate = dtp_termino.Date.AddMonths(1);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
            CalculoEvento c = new CalculoEvento
			{
				NomeEvento = Evento.Text,
				DataInicio = dtp_inicio.Date,
				DataTermino = dtp_termino.Date,
				Localizacao = Local.Text,
				NumeroPart = Convert.ToInt32(Participantes.Text),
				ValorPart = Convert.ToDecimal(ValorParticipante.Text),

            };
            await Navigation.PushAsync(new Calculo()
			{
				BindingContext = c
			});
		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Ok");
		}
    }

    private void dtp_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
		DatePicker elemento = sender as DatePicker;

		DateTime data_inicio = elemento.Date;

		dtp_termino.MinimumDate = data_inicio;
		dtp_termino.MaximumDate = data_inicio.AddMonths(2);
    }
}