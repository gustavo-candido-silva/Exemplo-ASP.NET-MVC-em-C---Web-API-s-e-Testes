using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMvc.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name="Descrição")]
        [Required(ErrorMessage="O campo não pode ser nulo!")]
        public string Descricao { get; set; }

    }
}
