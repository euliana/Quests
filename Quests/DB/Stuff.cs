//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quests.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stuff
    {
        public int IdStuff { get; set; }
        public int IdWorker { get; set; }
        public int IdRole { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
