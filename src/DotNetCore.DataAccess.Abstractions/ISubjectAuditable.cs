namespace DotNetCore.DataAccess.Abstractions
{
    public interface ISubjectAuditable<TSubjectKey>
    {
        TSubjectKey CreatedBy { get; set; }
        TSubjectKey ModifiedBy { get; set; }
    }
}
