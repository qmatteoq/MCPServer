using System.ComponentModel;
using MCPServer_Web.Entities;
using MCPServer_Web.Services;
using ModelContextProtocol.Server;
using Serilog;

[McpServerToolType]
public class EchoTool
{

    [McpServerTool, Description("Echoes the message back to the client.")]
    public string Echo(string message) => $"Hello from C#: {message}";

    [McpServerTool, Description("Echoes in reverse the message sent by the client.")]
    public string ReverseEcho(string message)  => new string(message.Reverse().ToArray());
}

[McpServerToolType]
public class WeatherTool
{
    private readonly IWeatherService _weatherService;
    public WeatherTool(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    [McpServerTool, Description("Get the current weather data for a given latitude and longitude.")]
    public async Task<WeatherData> GetWeatherAsync([Description("The latitude of the location")] double latitude, [Description("The longitude of the location")] double longitude)
    {
        return await _weatherService.GetWeatherAsync(latitude, longitude);
    }
}

[McpServerToolType]
public class EmployeeVacationTool
{
    private readonly IEmployeeVacationService _employeeVacationService;
    public EmployeeVacationTool(IEmployeeVacationService employeeVacationService)
    {
        _employeeVacationService = employeeVacationService;
    }

    [McpServerTool, Description("Get the vacation days left for a given employee.")]
    public async Task<int?> GetVacationDaysLeftAsync([Description("The name of the employee")] string employeeName)
    {
        return await _employeeVacationService.GetVacationDaysLeftAsync(employeeName);
    }

    [McpServerTool, Description("Charge vacation days for a given employee.")]
    public async Task<bool> ChargeVacationDaysAsync([Description("The name of the employee")] string employeeName, [Description("The number of days to charge")] int daysToCharge)
    {
        return await _employeeVacationService.ChargeVacationDaysAsync(employeeName, daysToCharge);
    }

    [McpServerTool, Description("Get the list of employees with their number of vacation days left")]
    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _employeeVacationService.GetAllEmployeesAsync();
    }
}
