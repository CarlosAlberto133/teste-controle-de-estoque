namespace controle_de_estoque_api.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }
    }
}
