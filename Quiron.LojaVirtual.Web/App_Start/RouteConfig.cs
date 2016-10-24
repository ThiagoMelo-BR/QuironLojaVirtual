using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
                /                  Produtos de todas as categorias
                /Pagina2           Todas as categorias da pagina 2
                /Futebol           Primeira página da categoria futebol
                /Futebol/Pagina2   Página 2 da categoria futebol
            */

            //1º
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null,
                    pagina = 1
                });

            //2º

            routes.MapRoute(null,
                "Pagina{pagina}",
                new { controller = "Vitrine",
                      action = "ListaProdutos",
                      categoria = (string)null }, 
                new { pagina = @"\d+" });

            //3º
            routes.MapRoute(null, "{categoria}", 
                new{
                controller = "Vitrine",
                action = "ListaProdutos",
                pagina = 1
            });

            //4º
            routes.MapRoute(null,
                "{categoria}Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos"
                },
                new { pagina = @"\d+" });

            //default
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
