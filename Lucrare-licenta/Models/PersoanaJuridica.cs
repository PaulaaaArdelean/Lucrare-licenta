﻿namespace Lucrare_licenta.Models
{
    public class PersoanaJuridica
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? TipSocietateID { get; set; }
        public TipSocietate? TipSocietate { get; set; }
    }
}
