namespace OpeaBook.Domain.Base
{
    public class Entity
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}