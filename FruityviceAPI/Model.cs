namespace FruityviceAPI
{
    public class Fruits
    {
        public string? Name { get; set; }
        public int Id { get; set; }
        public string? Family { get; set; }
        public string? Genus { get; set; }
        public string? Order { get; set; }
        public Nutrition? Nutritions { get; set; }
    }

    public class Nutrition
    {
        public double? Calories { get; set; }
        public double? Fat { get; set; }
        public double? Sugar { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Protein { get; set; }
    }
}
