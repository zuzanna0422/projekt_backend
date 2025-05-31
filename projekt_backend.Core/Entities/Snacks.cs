namespace projekt_backend.Core.Entities
{
    public class Snack
    {
        public int Id { get; set; }              // zakładam, że jest klucz główny
        public string CompetitorName { get; set; }
        public int Chocolate { get; set; }       // zakładam: 0 lub 1
        public int Fruity { get; set; }
        public int Caramel { get; set; }
        public int PeanutyAlmondy { get; set; }
        public int Nougat { get; set; }
        public int CrispedRiceWafer { get; set; }
        public int Hard { get; set; }
        public int Bar { get; set; }
        public int Pluribus { get; set; }
        public double SugarPercent { get; set; }
        public double PricePercent { get; set; }
        public double WinPercent { get; set; }
    }
}