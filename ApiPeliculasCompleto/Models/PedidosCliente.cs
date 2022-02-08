using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculasCompleto.Models
{
    [Table("VISTA_PELICULAS_PEDIDOS")]
    public class PedidosCliente
    {
        [Key]
        [Column("IDPELICULA")]
        public int IdPelicula { get; set; }
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }
        [Column("TITULO")]
        public string Titulo { get; set; }
        [Column("ARGUMENTO")]
        public string Argumento { get; set; }
        [Column("FOTO")]
        public string Foto { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("ACTORES")]
        public string Actores { get; set; }
        [Column("PRECIO")]
        public int Precio { get; set; }
        [Column("YOUTUBE")]
        public string YouTube { get; set; }
    }
}
