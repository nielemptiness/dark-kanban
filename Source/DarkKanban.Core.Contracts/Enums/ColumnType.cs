using System.ComponentModel;

namespace DarkKanban.Core.Contracts.Enums
{
    public enum ColumnType
    {
        Undefined,
        Custom,
        [Description("To do")]
        ToDo,
        [Description("Needs work")]
        NeedsWork,
        [Description("In progress")]
        InProgress,
        [Description("In review")]
        Review,
        [Description("Done")]
        Done
    }
}