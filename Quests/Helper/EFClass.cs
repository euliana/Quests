using Quests.DB;

namespace Quests.Helper
{
    internal class EFClass
    {
        public static QuestsEntities3 context { get; } = new QuestsEntities3();
    }
}
