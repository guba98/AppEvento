using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEvento.Models;

public class CalculoEvento
{
    public string NomeEvento { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public string Localizacao { get; set; }
    public int NumeroPart { get; set; }
    public decimal ValorPart { get; set; }
    public int Duracao => (DataTermino - DataInicio).Days + 1;
    public decimal CustoTotal => (NumeroPart * ValorPart) * Duracao;
}
