using ApiPeliculasCompleto.Models;
using ApiPeliculasCompleto.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculasCompleto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private RepositoryPeliculas repo;

        public PeliculasController(RepositoryPeliculas repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public List<Pelicula> GetPeliculas()
        {
            return this.repo.GetPeliculas();
        }

        [HttpGet("{id}")]
        public Pelicula FindPelicula(int id)
        {
            return this.repo.FindPelicula(id);
        }

        [HttpGet]
        [Route("[action]")]
        public List<Genero> Generos()
        {
            return this.repo.GetGeneros();
        }

        [HttpGet]
        [Route("[action]/{idcliente}")]
        public List<PedidosCliente> PedidosCliente(int idcliente)
        {
            return this.repo.GetPedidoCliente(idcliente);
        }

        [HttpGet]
        [Route("[action]/{idgenero}")]
        public List<Pelicula> PeliculasGenero(int idgenero)
        {
            return this.repo.GetPeliculasGenero(idgenero);
        }

        [HttpGet]
        [Route("[action]/{idcliente}")]
        public Cliente Cliente(int idcliente)
        {
            return this.repo.FindCliente(idcliente);
        }

        [HttpPost]
        [Route("[action]")]
        public void AddPedido(Pedido pedido)
        {
            this.repo.AddPedido(pedido.IdCliente, pedido.IdPelicula, pedido.Cantidad
                , pedido.Fecha, pedido.Precio);
        }
    }
}
