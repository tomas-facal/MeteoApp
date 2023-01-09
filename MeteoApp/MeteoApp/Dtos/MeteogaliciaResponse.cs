using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteoApp.Dtos
{
    public class Response
    {
        public PredDiaConcello predConcello { get; set; }

    }
    public class PredTresDias
    {
        public List<PredDia> ListaPredDiaConcello { get; set; }
    }
    public class PredDia
    {
        public string FechaPredicion { get; set; }
        public int TMax { get; set; }
        public int TMin { get; set; }
        public Pchoiva Plluvia { get; set; }
        public CEOResponse Cielo { get; set; }
    }
    public class PredDiaConcello
    {
        public int IdConcello { get; set; }
        public string Nome { get; set; }
        public List<Dia> ListaPredDiaConcello { get; set; }
    }

    public class Dia
    {
        public DateTime DataPredicion { get; set; }
        public int TMax { get; set; }
        public int TMin { get; set; }
        public Pchoiva Pchoiva { get; set; }
        public CEO CEO { get; set; }
    }

    public class Pchoiva
    {
        public int Mañana { get; set; }
        public int Tarde { get; set; }
        public int Noche { get; set; }
    }
    public class CEOResponse
    {
        public string Mañana { get; set; }
        public string Tarde { get; set; }
        public string Noche { get; set; }

    }
    public class CEO
    {
        public int Manha { get; set; }
        public int Tarde { get; set; }
        public int Noite { get; set; }
        Dictionary<int, string> CeoManhaTarde = new Dictionary<int, string>()
            {
               {-9999, "No disponible"},
               {101, "Despejado"},
               {102, "Nubes altas"},
               {103, "Nubes y claros"},
               {104, "Nublado 75%"},
               {105, "Cubierto"},
               {106, "Nieblas"},
               {107, "Chubasco"},
               {108, "Chubasco (75%)"},
               {109, "Chubasco nieve"},
               {110, "Llovizna"},
               {111, "Lluvia"},
               {112, "Nieve"},
               {113, "Tormenta"},
               {114, "Bruma"},
               {115, "Bancos de niebla"},
               {116, "Nubes medias"},
               {117, "Lluvia débil"},
               {118, "Chubascos débiles"},
               {119, "Tormenta con pocas nubes"},
               {120, "Agua nieve"},
               {121, "Granizo"}
            };
        Dictionary<int, string> CeoNoite = new Dictionary<int, string>()
{
    {9999, "No disponible"},
    {201, "Despejado"},
    {202, "Nubes altas"},
    {203, "Nubes y claros"},
    {204, "Nublado 75%"},
    {205, "Cubierto"},
    {206, "Nieblas"},
    {207, "Chubasco"},
    {208, "Chubasco (75%)"},
    {209, "Chubasco nieve"},
    {210, "Llovizna"},
    {211, "Lluvia"},
    {212, "Nieve"},
    {213, "Tormenta"},
    {214, "Bruma"},
    {215, "Bancos de niebla"},
    {216, "Nubes medias"},
    {217, "Lluvia débil"},
    {218, "Chubascos débiles"},
    {219, "Tormenta con pocas nubes" },
    {220, "Agua nieve" },
    {221, "Granizo" }
        };




        public string DescripcionManha
        {
            get
            {


                return CeoManhaTarde[Manha];
            }
        }

        public string DescripcionTarde
        {
            get
            {
                return CeoManhaTarde[Tarde];
            }
        }
        public string DescripcionNoite
        {
            get
            {
                return CeoNoite[Noite];
            }
        }
    }
}
