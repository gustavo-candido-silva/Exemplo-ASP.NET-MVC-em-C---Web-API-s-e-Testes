using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMvc.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        [Required(ErrorMessage="O campo não pode estar vazio!")]
        [Range(minimum:0,maximum:999)]
        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
