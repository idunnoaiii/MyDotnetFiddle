// See https://aka.ms/new-console-template for more information

using Helper;

var petsList =
    new List<Pet>
    {
        new Pet { Code = "A", Date = DateTime.Now.AddDays(-2).Date },
        new Pet { Code = "A", Date = DateTime.Now.AddDays(-1).Date },
        new Pet { Code = "B", Date = DateTime.Now.AddDays(0).Date },
        new Pet { Code = "B", Date = DateTime.Now.AddDays(-1).Date },
    };


var query = petsList.GroupBy(pet => pet.Code, pet => pet.Date, (s, times) =>
    new Dictionary<string, Dictionary<string, bool>>
    {
        { s, times.ToDictionary(x => $"{x.Year}_{x.Month}_{x.Day}", x => true) }
    });


query.Dump();

class Pet
{
    public string Code { get; set; }
    public DateTime Date { get; set; }
}