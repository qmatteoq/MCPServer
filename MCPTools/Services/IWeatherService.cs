public interface IWeatherService
{
    Task<WeatherData> GetWeatherAsync(double latitude, double longitude);
}