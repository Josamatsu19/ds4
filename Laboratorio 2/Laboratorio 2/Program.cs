using System;
namespace Laboratorio2
    {
    class programa
{
    static void Main(string[] args)
    {
        Client client = new Client();
        // ejemplo utulizando las variables de instancia de clase 
        client.FirstName = "Jose";
        client.LastName = "Luna";
        client.Age = 20;
        client.Id = 1;

        Console.WriteLine(client.GetFullName());
    }
}
public class Client
{
    //declarando las variables 
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ushort Age { get; set; }
    public string GetFullName()
    {
        // utilizando variables de instancia dentro de metodos de la clase 
        return FirstName + " " + LastName;
    }

}
}