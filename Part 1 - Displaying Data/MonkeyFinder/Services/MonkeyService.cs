using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    // this class is built specifically for retrieving things from the internet
    HttpClient httpClient;

    public MonkeyService()
    {
        httpClient = new HttpClient();
    }
    List<Monkey> monkeyList = new ();
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
        {
            return monkeyList;
        }
        else 
        { 

        //else
        /* var url = "https://montemango.com/monkeys.json";
         var response = await httpClient.GetAsync(url); 

         if(response.IsSuccessStatusCode)
         {
             monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
         } */

        //getting the data from the resources folder in the application
        using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
        }
        return monkeyList;
    }
}
