using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("pais")]
    public class Pais :ModelBase
    {
        public string Nome { get; set; }
        public string? CodigoBacen { get; set; }
    }
}
