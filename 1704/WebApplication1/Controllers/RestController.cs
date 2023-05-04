using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestController : ControllerBase
    {
        //[HttpGet("[action]/{id}")]
        //public IActionResult Index(int id)
        //{
        //    return id % 2 != 0 ? BadRequest() : Ok("Число чётное");
        //}
        // -----------------------------
        //[HttpGet("{id}/[action]")]
        //public IActionResult Index(int id)
        //{
        //     return id % 2 != 0 ? BadRequest() : Ok("Число чётное");
        //}
        //--------------------

        // https://localhost:7100/api/rest/index?id=1
        //[HttpGet("[action]")]
        //public IActionResult Index(int id)
        //{
        //    return id % 2 != 0 ? BadRequest() : Ok("Число чётное");
        //}
        //--------------------
        //https://localhost:7100/api/rest/check-number/2
        //[HttpGet("check-number/{id}")]
        //public IActionResult Index(int id)
        //{
        //    return id % 2 != 0 ? BadRequest() : Ok("Число чётное");
        //}

        //--------------------


        //PUT https://localhost:7100/api/rest/check-number/1
        //[HttpPut("check-number/{id}")]
        //public IActionResult Index(int id)
        //{
        //    return id % 2 != 0 ? BadRequest() : Ok("Число чётное");
        //}


        //        3.
        //На сервере есть файл сервисов.В нем глобально хранится массив.Прописать
        //логику так, чтобы при get запросе отправлялся ответ клиенту с массивом внутри
        //тела
        //[HttpPut("check-number/{id}")]
        //public IActionResult GetArray()
        //{
        //    return Ok(ArrayService.Array);

        //}

        //--------------------
        //[HttpGet("check-number/{id}")]
        //public string[] GetArray()
        //{
        //    return ArrayService.Array;
        //}
        //        5.
        //Добавить 1 обработчик маршрута : get с url “/:id”. На сервере есть файл сервисов.В
        //нем глобально хранится массив объектов.Прописать логику так, чтобы при get
        //запросе отправлялся ответ клиенту с объектом, id которого совпадает с
        //запрашиваемым id, статус ответа
        [HttpGet("[action]/{index}")]
        public IActionResult GetArray(int index)
        {
            try
            {
                return Ok(ArrayService.Array[index - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest();
            }
        }
        [HttpGet("[action]")]
        public List<string> GetArray()
        {

            return ArrayService.Array;


        }

        //        6.
        //Для post запроса добавить добавление тела запроса в массив и возвращать
        //обновленный массив, статус ответа
        [HttpPost("[action]")]
        public IActionResult AddItem(ArrayItemModel data)
        {
            if (data.Item == null) return BadRequest();
            ArrayService.Array.Add(data.Item);
            return Ok(GetArray());
        }


        //        7.
        //Добавить 2 обработчика маршрута put, delete
        //https://localhost:7100/api/rest/DeleteByIndex/2
        [HttpDelete("[action]/{index}")]

        public IActionResult DeleteByIndex(int index)
        {
            try
            {
                ArrayService.Array.RemoveAt(index);
                return Ok(ArrayService.Array);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }


        [HttpPut("[action]/{index}")]


        //https://localhost:7100/api/rest/UpdateItem/1
        public IActionResult UpdateItem([FromBody] ArrayItemModel data, int index)
        {
            if (data.Item == null) return BadRequest();

            try
            {

                ArrayService.Array[index - 1] = data.Item;
                return Ok(GetArray());
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }

        [HttpPost("[action]/{split}")]

        public IActionResult ShowResult(int split, [FromBody] List<int> array) //List<List<int>>
        {
            if (split <= 0) return BadRequest();
            if (array.Count == 0) return BadRequest();
            //List<List<int>> result = new List<List<int>>();
            //List<int> itemresult = new List<int>();
            //for (int i = 0; i < array.Count; i++)
            //{
            //    itemresult.Add(array[i]);
            //    if (itemresult.Count == split)
            //    {
            //        result.Add(itemresult);
            //        itemresult = new List<int>();
            //    }
            //}
            //if (itemresult.Count > 0)
            //{
            //    result.Add(itemresult);
            //}
            List<List<int>> result = new List<List<int>>() { new List<int>() };
            for (int i = 0; i < array.Count; i++)
            {
                var itemresult = result.Last();
                itemresult.Add(array[i]);
                if (itemresult.Count == split && i != array.Count-1)
                {
                    result.Add(new List<int>());
                }
            }

            //var result = array.Select((value, index) => new { Index = index, Value = value }).GroupBy(x => x.Index / split).Select(o => o.Select(y => y.Value));

            return Ok(result);
        }

    }
}
