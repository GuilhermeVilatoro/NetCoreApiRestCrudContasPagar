using System.ComponentModel;

namespace ContaPagar.Domain.Enums
{
    public enum TipoRegraEnum : byte
    {
        [Description("Até 3 dias")]
        AteTresDias = 0,

        [Description("Superior a 3 dias")]
        SuperiorTresAteCincoDias = 1,

        [Description("Superior a 5 dias")]
        SuperiorCincoDias = 2
    }
}