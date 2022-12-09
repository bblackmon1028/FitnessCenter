using Newtonsoft.Json;
using NugetDemo;


Student student = new Student() { FirstName = "Grant", LastName = "Chirpus" };
string json = JsonConvert.SerializeObject(student);
Console.WriteLine(json);

Console.ReadLine();


Student student2 = JsonConvert.DeserializeObject<Student>(json);