namespace MovieApp.Data.DTOs.Generics
{
    public class AuditedBaseDTO:BaseDTO
    {
        public DateTime CreatedAt { get; set; }
    }
}
