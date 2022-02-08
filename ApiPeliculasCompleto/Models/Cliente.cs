﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculasCompleto.Models
{
    [Table("CLIENTES")]
    public class Cliente
    {
        [Key]
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("PAGINAWEB")]
        public string PaginaWeb { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
    }
}
