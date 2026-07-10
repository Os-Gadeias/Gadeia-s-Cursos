
using System.Text.RegularExpressions;
using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCategoria
{
    public class Categoria : EntidadeBase<Categoria>
    {
        public string Icon { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;

        public Categoria()
        {
        }

        public Categoria(string icon, string titulo, string cor)
        {
            Icon = icon;
            Titulo = titulo;
            Cor = cor;
        }

        public override void Atualizar(Categoria entidadeAtualizada)
        {
            Icon = entidadeAtualizada.Icon;
            Titulo = entidadeAtualizada.Titulo;
            Cor = entidadeAtualizada.Cor;
        }

        public override List<string> Validar()
        {
            List<string> erros = [];

            if (!Icon.IsEmoji())
                erros.Add("O campo \"Icone\" deve ser um Emoji!");

            if (Titulo.Length < 2 || Titulo.Length > 100)
                erros.Add("O campo \"Título\" deve conter entre 2 à 100 caracteres");

            return erros;
        }
    }
}
public static class StringExtensions
{
    // Regex que cobre a maioria dos emojis modernos
    private static readonly Regex EmojiRegex = new Regex(
        @"(\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]|\ud83e[\ud000-\udfff])",
        RegexOptions.Compiled);

    public static bool IsEmoji(this string input)
    {
        return !string.IsNullOrEmpty(input) && EmojiRegex.IsMatch(input);
    }
}