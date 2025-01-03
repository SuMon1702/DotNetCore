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
            var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
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

            List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
            {
                ProverbId = x.ProverbId,
                ProverbName = x.ProverbName,
                TitleId = x.TitleId
            }).ToList();                   // drr yay lite tot drr ka description ma pr bl tachr 3 khu htoke tr fyit twr dl

            return Ok(lst);

        }

        [HttpGet("{titleId}/{proverbId}")]
        public async Task<IActionResult> Get(int titleId, int proverbId)
        {
            var model = await GetDataFromApi();
            var item = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);

            return Ok(item);

            // drr ka titleid ka က,ခ ty yk id ka 1,2 so to 1,2 yay. proverbid ka ae က,ခ yk bl taku proverb ko ti chin tr ll aedr ko ll 1,2 nk yay
            // က htl ka bl proverb so pee htwt mr
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

    
}
