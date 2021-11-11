namespace Site.Services;

public interface IHelloService
{
  public string Greet(string name);
}

public class HelloService : IHelloService
{

  public string Greet(string name) =>
    $"Hello {name ?? "world"}";

}