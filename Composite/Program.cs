
namespace Composite {
  class Program {
    static void Main()
        {
          MenuSection rootMenu = new MenuSection("Menu");

          MenuSection mainSection = new MenuSection("Dania");
          rootMenu.Add(mainSection);

          mainSection.Add(new MenuItem("Frytki z sosem tatarskim"));
          mainSection.Add(new MenuItem("Pizza margherita"));

          MenuSection meatSection = new MenuSection("Mięsne");
          mainSection.Add(meatSection);
          meatSection.Add(new MenuItem("Kotlet schabowy z surówką"));
          meatSection.Add(new MenuItem("Gulasz wołowy"));

          MenuSection fishSection = new MenuSection("Rybne");
          mainSection.Add(fishSection);
          fishSection.Add(new MenuItem("Łosoś wędzony w sosie"));

          rootMenu.Print(0);
        }
  }
}

