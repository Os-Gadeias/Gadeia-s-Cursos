using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

    public class ApenasUmEmojiAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            // Se for nulo ou vazio, a validação passa. 
            // Quem deve barrar campo vazio é o atributo [Required].
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string texto = value.ToString().Trim();

            // 1. O "Pulo do Gato": Conta os blocos visuais (Grapheme Clusters)
            // Isso garante que emojis complexos (como 👨‍👩‍👧‍👦) sejam lidos como 1 único item.
            StringInfo stringInfo = new StringInfo(texto);
            if (stringInfo.LengthInTextElements != 1)
            {
                return new ValidationResult(ErrorMessage ?? "Por favor, insira exatamente 1 emoji.");
            }

            // 2. Verifica se o item inserido é de fato um caractere do tipo Símbolo/Emoji
            // Expressão regular que cobre a grande maioria dos blocos Unicode de Emojis
            bool isEmoji = Regex.IsMatch(texto, @"(\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]|\ud83e[\ud000-\udfff])");

            if (!isEmoji)
            {
                return new ValidationResult("O texto inserido deve ser um emoji válido.");
            }

            return ValidationResult.Success;
        }
    }
