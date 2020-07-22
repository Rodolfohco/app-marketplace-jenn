using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    public class Logon: IdentityUser
    {
        public int Ativo { get; set; }
        
        public Guid UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataInclusao { get; set; }

    }
}
