using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoWeb.Models
{
    [Table("solutech_tb_investimento")]
    public class Investimento
    {
        [Key]
        public int Id { get; set; }  // Identificador único do investimento (Chave Primária)
        [Required]
        public string NomeAtivo { get; set; }  // Nome do ativo financeiro

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorInvestido { get; set; }  // Valor investido no ativo

        [Required]
        public DateTime DataCompra { get; set; }  // Data de compra do ativo

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorAtual { get; set; }  // Valor atual do ativo

        [Required]
        public DateTime DataAtualizacao { get; set; }  // Data e hora da última atualização do investimento
    }

}
