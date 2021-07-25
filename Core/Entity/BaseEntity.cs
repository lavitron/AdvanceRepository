using System;

namespace Core.Entity
{
    public class BaseEntity : Audit, ISoftDelete
    {
        protected BaseEntity()
        {
            IsDeleted = false;
            CDate = DateTime.Now;
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}