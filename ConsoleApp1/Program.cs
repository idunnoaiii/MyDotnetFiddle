// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;

var c = Channel.CreateBounded<bool>(1);

Task.Run(async() => {
    var value = await c.Reader.ReadAsync();
    System.Console.WriteLine(value);
});

Task.Run(async() => {
    await Task.Delay(3000);
    await c.Writer.WriteAsync(true);
});

await Task.Delay(4000);