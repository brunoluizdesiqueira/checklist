using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckList.Enums;

namespace CheckList.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public IList<Comentario> ListaComentarios { get; set; }
        [Required]
        public StatusTarefaEnum Status { get; set; }
    }
}