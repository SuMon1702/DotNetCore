using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SMDotNetCore.RestApiWithNLayer.LatHtukBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LHBDController : ControllerBase
    {
    }
}



public class LatHtukBayDin
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
