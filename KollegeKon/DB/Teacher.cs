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
    
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            this.Couple = new HashSet<Couple>();
            this.Task = new HashSet<Task>();
            this.Grade = new HashSet<Grade>();
        }
    
        public int Id { get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Speciality { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int IdGender { get; set; }
        public string Address { get; set; }
        public Nullable<int> IdAccount { get; set; }
    
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Couple> Couple { get; set; }
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Task { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
