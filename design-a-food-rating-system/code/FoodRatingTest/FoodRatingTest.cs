namespace FoodRatingTest;
using FoodRatings;

// Input
//         ["FoodRatings", "highestRated", "highestRated", "changeRating", "highestRated", "changeRating", "highestRated"]
//     [[["kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi"], ["korean", "japanese", "japanese", "greek", "japanese", "korean"], [9, 12, 8, 15, 14, 7]], ["korean"], ["japanese"], ["sushi", 16], ["japanese"], ["ramen", 16], ["japanese"]]
// Output
//     [null, "kimchi", "ramen", null, "sushi", null, "ramen"]

[TestClass]
public class FoodRatingTest
{
    [TestMethod]
    public void Pass_Rating_ReturnsHighest()
    {
        // Arrange
        var Foods = new string[] {"kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" };
        var Cuisines = new string[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" };
        var Ratings = new int[] { 9, 12, 8, 15, 14, 7 };
        
        // Act
        var foodRatings = new FoodRatings(Foods, Cuisines, Ratings);
        
        // Assert
        Assert.AreEqual(foodRatings.HighestRated("korean"), "kimchi");
    }
    
    [TestMethod]
    public void Modify_Rating_ReturnsHighest()
    {
        // Arrange
        var Foods = new string[] {"kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" };
        var Cuisines = new string[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" };
        var Ratings = new int[] { 9, 12, 8, 15, 14, 7 };
        
        // Act
        var foodRatings = new FoodRatings(Foods, Cuisines, Ratings);
        foodRatings.ChangeRating("ramen",16);
        
        // Assert
        Assert.AreEqual(foodRatings.HighestRated("japanese"), "ramen");
    }
    
    [TestMethod]
    public void Modify_RatingOfAnother_ReturnsHighest()
    {
        // Arrange
        var Foods = new string[] {"kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" };
        var Cuisines = new string[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" };
        var Ratings = new int[] { 9, 12, 8, 15, 14, 7 };
        
        // Act
        var foodRatings = new FoodRatings(Foods, Cuisines, Ratings);
        foodRatings.ChangeRating("sushi",16);
        
        // Assert
        Assert.AreEqual(foodRatings.HighestRated("japanese"), "sushi");
    }
    
    [TestMethod]
    public void Modify_SameRating_ReturnsHighestLexicographicallySmaller()
    {
        // Arrange
        var Foods = new string[] {"kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" };
        var Cuisines = new string[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" };
        var Ratings = new int[] { 9, 12, 8, 15, 14, 7 };
        
        // Act
        var foodRatings = new FoodRatings(Foods, Cuisines, Ratings);
        foodRatings.ChangeRating("sushi",16);
        foodRatings.ChangeRating("ramen",16);
        
        // Assert
        Assert.AreEqual(foodRatings.HighestRated("japanese"), "ramen");
    }
}