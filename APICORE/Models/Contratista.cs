namespace APICORE.Models
{
    public class Contratista
    {
        public int iIdContratista { get; set; }
        public string vRuc { get; set; }
        public string vRazonSocial { get; set; }
        public string vRepresentante { get; set; }
        public string vCorreo { get; set; }
        public string vTelefono { get; set; }
        public int iEstado { get; set; }
        public DateTime dfechaRegistro { get; set; }
        public decimal fLatitud { get; set; }
        public decimal fLongitud { get; set; }
    }
}
