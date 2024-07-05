using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("municipio")]
    public class Municipio : ModelBase
    {
        public string Descricao { get; set; }
        public int EstadoId { get; set; }
        [ForeignKey(nameof(EstadoId))]
        public Estado Estado { get; set; }
    }
}
