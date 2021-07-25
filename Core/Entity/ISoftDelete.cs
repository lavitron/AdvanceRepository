namespace Core.Entity
{
    /// <summary>
    ///     Is entity deleted softly
    /// </summary>
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}