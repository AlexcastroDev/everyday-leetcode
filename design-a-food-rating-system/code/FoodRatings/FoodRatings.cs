namespace FoodRatings;
using System;
using System.Linq;
record Food(string Name, int Rating);

public class FoodRatings
{
	private string[] _foods;
	private string[] _cuisines;
	private int[] _ratings;
	
	public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
	{
		_foods = foods;
		_cuisines = cuisines;
		_ratings = ratings;
	}

	public void ChangeRating(string food, int newRating)
	{
		var index = Array.IndexOf(_foods, food);
		_ratings[index] = newRating;
	}
	
	public string? HighestRated(string cuisine)
	{
		var data = Enumerable.Range(0, _cuisines.Length)
			.Where(i => _cuisines[i] == cuisine)
			.Select(x => new Food(_foods[x], _ratings[x]));
		
		var max = data.Max(x => x.Rating);
		var test = data.Where(x => x.Rating == max)
			.OrderByDescending(x => x.Rating)
			.ThenBy(x => x.Name)
			.FirstOrDefault();
		
		return test?.Name;
	}
}