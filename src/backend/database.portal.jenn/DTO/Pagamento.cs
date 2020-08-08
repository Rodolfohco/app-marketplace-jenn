using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

  
    [Table("pgto")]
    public class Pagamento
    {
        [Key]
        [Column("cod_pgto", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagamentoID { get; set; }

        [Required]
        [Column("nom_pgto", Order = 1)]
        [StringLength(200)]
        public string Nome { get; set; }
                
    }


   
}
