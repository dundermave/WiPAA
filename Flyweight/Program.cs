
namespace Flyweight {
  class Program
  {
      static void Main()
      {
          var factory = new ResourceFactory();

          var obj1 = new SceneObject(10, 20, "assets/wood.png", factory);
          var obj2 = new SceneObject(30, 40, "assets/wood.png", factory);   // ten sam zasób
          var obj3 = new SceneObject(50, 60, "assets/stone.png", factory);  // inny zasób

          obj1.Render();
          obj2.Render();
          obj3.Render();

          Console.WriteLine($"Total unique resources loaded: {factory.Count}");
      }
  }
}