// See https://aka.ms/new-console-template for more information

var client = new  HttpClient();

client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

var response = await  client.GetStringAsync("/posts/1");

Console.WriteLine(response);
