namespace Composite
{
    class Program
    {
        static void Main()
        {
            MenuSection rootMenu = new MenuSection("Karta dań");

            MenuSection startersSection = new MenuSection("Przystawki");
            rootMenu.Add(startersSection);
            startersSection.Add(new MenuItem("Bruschetta z pomidorami"));
            startersSection.Add(new MenuItem("Zupa krem z dyni"));

            MenuSection mainDishesSection = new MenuSection("Dania główne");
            rootMenu.Add(mainDishesSection);

            MenuSection vegetarianSection = new MenuSection("Wegetariańskie");
            mainDishesSection.Add(vegetarianSection);
            vegetarianSection.Add(new MenuItem("Risotto z grzybami"));
            vegetarianSection.Add(new MenuItem("Makaron z pesto bazyliowym"));

            MenuSection grillSection = new MenuSection("Z grilla");
            mainDishesSection.Add(grillSection);
            grillSection.Add(new MenuItem("Stek wołowy z masłem czosnkowym"));
            grillSection.Add(new MenuItem("Pierś kurczaka grillowana"));

            MenuSection dessertsSection = new MenuSection("Desery");
            rootMenu.Add(dessertsSection);
            dessertsSection.Add(new MenuItem("Sernik waniliowy"));
            dessertsSection.Add(new MenuItem("Mus czekoladowy"));

            rootMenu.Print(0);
        }
    }
}
