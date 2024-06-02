using Quests.DB;

namespace Quests.Helper
{
    internal class AppData
    {
        public static QuestsEntities3 Context { get; } = new QuestsEntities3 ();
    }
}
