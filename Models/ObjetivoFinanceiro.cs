using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoWeb.Models
{
    [Table("solutech_tb_objetivo_financeiro")]
    public class ObjetivoFinanceiro
    {
        [Key]
        public int Id { get; set; }  // Identificador único do objetivo financeiro (Chave Primária)

        [Required]
        public string Nome { get; set; }  // Nome descritivo do objetivo financeiro

        [Required]
        public string Descricao { get; set; }  // Descrição detalhada do objetivo financeiro

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorAlvo { get; set; }  // Valor alvo a ser alcançado para o objetivo financeiro

        [Required]
        public DateTime Prazo { get; set; }  // Data prevista para alcançar o objetivo financeiro

        [Required]
        public string Status { get; set; }  // Status atual do objetivo financeiro (em andamento, concluído, etc.)

        [Required]
        public DateTime DataCriacao { get; set; }  // Data e hora de criação do objetivo financeiro

    }
}
