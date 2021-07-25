using System;

namespace Core.Entity
{
    /// <summary>
    ///     Database audit information
    /// </summary>
    public abstract class Audit
    {
        public int CUserId { get; set; }
        public DateTime CDate { get; set; }
        public int? MUserId { get; set; }
        public DateTime MDate { get; set; }
    }
}