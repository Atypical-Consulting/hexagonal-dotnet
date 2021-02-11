using System;
using System.ComponentModel.DataAnnotations;
using Ideator.Application.Article;
using Ideator.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ideator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleFacade _articles;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(
            ArticleFacade articles,
            ILogger<ArticleController> logger)
        {
            _articles = articles;
            _logger = logger;
        }

        [HttpGet("{articleId:guid}")]
        public ActionResult<ArticleResponse> Get(
            [FromRoute] [Required] Guid articleId)
        {
            var id = new ArticleId(articleId);
            
            var articleResponse = _articles.Get(id);

            return Ok(articleResponse);
        }

        [HttpPost]
        public ActionResult<ArticleIdResponse> Create(
            [FromForm] [Required] string title,
            [FromForm] [Required] string content,
            [FromForm] [Required] Guid authorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createArticleRequest = new CreateArticleRequest(
                new Title(title),
                new Content(content),
                new AuthorId(authorId));
            
            var articleIdResponse = _articles.Create(createArticleRequest);

            return Ok(articleIdResponse); 
        }
    }
}