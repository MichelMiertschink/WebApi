using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("estado")]
    public class Estado : ModelBase
    {
        public string Descricao { get; set; }
        public string Cod {  get; set; }
        public int PaisId  { get; set; }
        [ForeignKey(nameof(PaisId))]

        public Pais Pais { get; set; }
    }
}
