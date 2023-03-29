namespace Test_xUnit;

[Collection("TestCollection2")]
public class TestClass2
{
    [Fact]
    public async Task Test1()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
    }


    [Fact]
    public async Task Test2()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}