// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Maximum Floor Number:");
int topLevel = int.Parse(Console.ReadLine().ToString());
Console.WriteLine("Number of gifts(max:24):");
int totGifts = int.Parse(Console.ReadLine().ToString());
Console.WriteLine();

var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://www.safe.gov.cn/AppStructured/hlw/RMBQuery.do"),
    Headers =
    {
        { "Origin", "" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    //Console.WriteLine(body);
    Regex rx = new Regex(@"[0-9]{4}-[0-9]{2}-[0-9]{2}", RegexOptions.Compiled);
    var matches = rx.Matches(body);
    for (int m = matches.Count - 1; m >= 0; m--)
    {
        Console.WriteLine(matches[m].Groups[0]);
        Console.WriteLine("Original Exchange Rate:");
        Regex rxCurrency = new Regex(@"<td td width=""8%"" align=""center"" >\W+([0-9]+\.[0-9]+)", RegexOptions.Compiled | RegexOptions.Singleline);
        var currencyMatches = rxCurrency.Matches(body, matches[m].Index);
        for (int i = 0; i < 24; i++)
        {
            Console.Write(currencyMatches[i].Groups[1] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Lucky Winners: ");
        HashSet<int> dedup = new HashSet<int>();
        for (int i = 0; i < 24; i++)
        {
            dedup.Add(int.Parse(currencyMatches[i].Groups[1].ToString().Replace(".", "")) % (topLevel - 1));
        }
        List<int> luckys = dedup.ToList();
        for (int i = 0; i < Math.Min(luckys.Count, totGifts); i++)
        {
            Console.Write((luckys[i] + 2) + " ");
        }
        //luckys.Sort();
        //luckys.ForEach(i => Console.Write(i + " "));
        Console.WriteLine();
        Console.WriteLine();
     

    }
    Console.ReadKey();

}