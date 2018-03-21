using System.ComponentModel.DataAnnotations;

namespace Conectt.Enum
{
    public enum ETipoMensagem
    {
        Sucesso = 0 ,
        [Display(Name = "Atenção")]
        Atencao = 1,
        Falha = 2
    }
}
