namespace OnboardingSIGDB1.API.Filtros
{
    /// <summary>
    /// Filtros para consulta da funcionário
    /// </summary>
    public class FiltrosFuncionario : FiltrosBase
    {
        /// <summary>
        /// Cnpj da empresa
        /// </summary>
        public string Cpf { get; set; }
    }
}
