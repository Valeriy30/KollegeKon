//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KollegeKon.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Journal
    {
        public int IdCouple { get; set; }
        public int IdStudent { get; set; }
        public int IdGrade { get; set; }
    
        public virtual Couple Couple { get; set; }
        public virtual Student Student { get; set; }
        public virtual Grade Grade { get; set; }
    }
}
