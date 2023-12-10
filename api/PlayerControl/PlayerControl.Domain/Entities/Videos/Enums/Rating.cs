using System.ComponentModel;

namespace PlayerControl.Domain.Entities.Videos.Enums
{
    public enum Rating
    {
        [Description("Classificação Livre")]
        L,
        [Description("Não recomendado para menores de 10 (dez) anos")]
        R10,
        [Description("Não recomendado para menores de 12 (doze) anos")]
        R12,
        [Description("Não recomendado para menores de 14 (quatorze) anos")]
        R14,
        [Description("Não recomendado para menores de 16 (dezesseis) anos")]
        R16,
        [Description("Não recomendado para menores de 18 (dezoito) anos")]
        R18
    }
}
