namespace MovieApp.Data.Generics
{
    public class AuditedBaseModel:BaseModel
    {
        public DateTime CreatedAt { get; set; }= DateTime.Now;
    }
}
