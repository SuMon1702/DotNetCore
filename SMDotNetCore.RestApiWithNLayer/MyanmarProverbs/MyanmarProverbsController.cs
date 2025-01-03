using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SMDotNetCore.RestApiWithNLayer.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {

        private async Task<Tbl_Mmproverbs> GetDataFromApi()
        {
            var jsonStr = await System.IO.File.ReadAllTextAsync("data2.json");
            var model= JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
            return model!;

        }

        //drr ka all swl htoke tr
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await GetDataFromApi();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("{titleName}")]
        public async Task<IActionResult> Get(string titleName)
        {
            var model = await GetDataFromApi();
            var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
            if (item is null) return NotFound();

            var titleId = item.TitleId;
            var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);//di hti ka ko ka က yk hrr ya chin yin က ko titlename mr yite yin thu nk sine tk hrr pw lr mr

            return Ok(result);


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

    }
}
