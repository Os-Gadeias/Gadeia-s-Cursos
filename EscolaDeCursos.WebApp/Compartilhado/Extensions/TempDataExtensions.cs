using FluentResults;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EscolaDeCursos.WebApp.Compartilhado.Extensions;

public static class TempDataExtensions
{
    public static void AddErrorMessage(this ITempDataDictionary tempData, ResultBase result)
    {
        tempData["MensagemErro"] = result.Errors.First().Message;
    }
    public static void AddSucessMessage(this ITempDataDictionary tempData, string mensagem)
    {
        tempData["MensagemSucesso"] = mensagem;
    }
}
