namespace CRUDNETBDD.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionString: CadenaSQL").Value;
        }

        public string getCadenaSQL() { return cadenaSQL; }//Especie de getter de la clase

    }
}
