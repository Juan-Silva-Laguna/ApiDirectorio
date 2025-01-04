namespace DirectorioLocal.Core.Entities
{
    public partial class PaisesEstadosCiudades
    {
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
    }
}
