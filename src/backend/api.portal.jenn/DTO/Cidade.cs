using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

    [Table("cidade")]
    public class Cidade
    {
        [Key]
        [Column("cod_cidade", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CidadeID { get; set; }

        [Required]
        [Column("nom_cid", Order = 3)]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Column("cod_uf", Order = 3)]
        [StringLength(2)]
        public string UF { get; set; }


        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }


        public virtual ICollection<Regiao> Regiao { get; set; }
        public virtual ICollection<UF> Ufs { get; set; }
    }

   


    

}
