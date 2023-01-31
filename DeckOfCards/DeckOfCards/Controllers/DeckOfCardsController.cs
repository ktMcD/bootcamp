using DeckOfCards.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Windows;

namespace DeckOfCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckOfCardsController : Controller
    {
        public IActionResult Index()
        {
            string apiUri = "https://www.deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
            var apiTask = apiUri.GetJsonAsync<RootObject>();
            apiTask.Wait();
            RootObject result = apiTask.Result;
            return View(result);

        }

        public IActionResult List()
        {
            var apiUri = "https://www.deckofcardsapi.com/api/deck/new/draw/?count=5";
            var apiTask = apiUri.GetJsonAsync<List<Card>>();
            apiTask.Wait();
            List<Card> newHand = apiTask.Result;
            return View(newHand);
        }

    }


}
