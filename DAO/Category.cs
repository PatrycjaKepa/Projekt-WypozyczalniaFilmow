namespace Projekt_WypozyczalniaFilmow.DAO
{
    public class Category
    {
        public int Id { get; }
        public string Name { get; }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
