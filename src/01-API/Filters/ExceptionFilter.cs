using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RotaDeViagem.Domain.Commands.Response;
using RotaDeViagem.Shared.Exceptions;

namespace RotaDeViagem.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //long personId = 0;
            //if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out var auth))
            //{
            //    try
            //    {
            //        var handler = new JwtSecurityTokenHandler();
            //        var jsonToken = handler.ReadToken(auth.ToString().Replace("Bearer ", ""));
            //        var tokenS = jsonToken as JwtSecurityToken;
            //        personId = long.Parse(tokenS.Claims.First(claim => claim.Type == "pid").Value);
            //    }
            //    catch
            //    {
            //        personId = 0;
            //    }
            //}

            var status = 500;
            if (context.Exception is DomainException
                    || context.Exception.InnerException is DomainException
                    )
            {
                status = 400;
            }
            else if (context.Exception is NotFoundException
                   || context.Exception.InnerException is NotFoundException
                   )
            {
                status = 404; // Toda vez que um registro não for encontrado retornaremos
                              // 200. Indicando que a consulta foi realizada sem erros, porém
                              // porém não existe registro na base de dados.
            }


            var mensagem = status == 400 || status == 404 ? (
                            context.Exception.InnerException == null ? context.Exception.Message
                            : context.Exception.InnerException.Message)
                                    : "Ocorreu uma falha inesperada no servidor";
            var response = context.HttpContext.Response;

           

            response.StatusCode = status;
            response.ContentType = "application/json";
            context.Result = new JsonResult(new GenericResponse(false, mensagem));
        }
    }
}
