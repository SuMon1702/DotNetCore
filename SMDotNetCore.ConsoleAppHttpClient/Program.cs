using Newtonsoft.Json;


Console.WriteLine("Hello, World!");

string jsonStr = await File.ReadAllTextAsync("data.json");
var model= JsonConvert.DeserializeObject<MainDto>(jsonStr);


//Question Number ty ko swl htoke trr
foreach (var item in model!.questions)
{
    Console.WriteLine(item.questionNo);
}

Console.WriteLine(jsonStr);

//Change Myan Number to English Number
static string MyanToEng(string num)
{
    num = num.Replace("၀", "0");
    num = num.Replace("၁", "1");
    num = num.Replace("၂", "2");
    num = num.Replace("၃", "3");
    num = num.Replace("၄", "4");

    return num;
}




public class MainDto
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}


