using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SMDotNetCore.RestApiWithNLayer.Features.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private async Task<Tbl_Mmproverbs> GetDataFromApi()
        {
            //HttpClient client = new HttpClient();
            //var response = await client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
            //if (!response.IsSuccessStatusCode) return null;

            //string jsonStr = await response.Content.ReadAsStringAsync();
            //var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
            //return model!;

            var jsonStr = await System.IO.File.ReadAllTextAsync("data2.json");
            var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
            return model!;
        }

    }
}

public class Tbl_Mmproverbs
{
    public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
    public Tbl_MmproverbsDetail[] Tbl_MMProverbs { get; set; }
}

public class Tbl_Mmproverbstitle
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
}

public class Tbl_MmproverbsDetail
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
    public string ProverbDesp { get; set; }
}
public class Tbl_MmproverbsHead
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
}