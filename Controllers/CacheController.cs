using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cache")]
public class CacheController : ControllerBase
{
    private static LRUCache cache = new LRUCache(3);

    [HttpGet("{key}")]
    public IActionResult Get(int key)
    {
        int value = cache.Get(key);
        if (value == -1)
            return NotFound("Key not found");

        return Ok(value);
    }

    [HttpPost]
    public IActionResult Put(int key, int value)
    {
        cache.Put(key, value);
        return Ok("Inserted/Updated");
    }
}
