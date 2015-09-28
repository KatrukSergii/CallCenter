public interface ICampagne
{
    int Id { get; set; }
    string Name { get; set; }   

    ICallCenter CallCenter { get; set; }
}