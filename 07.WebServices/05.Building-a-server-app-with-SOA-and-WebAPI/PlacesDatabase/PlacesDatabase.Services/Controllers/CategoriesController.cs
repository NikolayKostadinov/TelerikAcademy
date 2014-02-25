using PlacesDatabase.DataLayer;
using PlacesDatabase.Models;
using PlacesDatabase.Repositories;
using PlacesDatabase.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlacesDatabase.Services.Controllers
{
    public class CategoriesController : ApiController
    {
        private IRepository<Category> categoryRepository;

        public CategoriesController()
        {
            var dbContext = new PlacesContext();
            this.categoryRepository = new DbCategoriesRepository(dbContext);
        }

        public CategoriesController(IRepository<Category> repository)
        {
            this.categoryRepository = repository;
        }

        [HttpGet]
        public IEnumerable<CategoryModel> GetAll()
        {
            var categoryEntities = this.categoryRepository.All().ToList();

            var categoryModels =
                from categoryEntity in categoryEntities
                select new CategoryModel()
                {
                    Id = categoryEntity.Id,
                    Name = categoryEntity.Name,
                    PlacesCount = (categoryEntity.Places != null) ? categoryEntity.Places.Count : 0
                };

            return categoryModels.ToList();
        }

        [HttpGet]
        public CategoryFullModel GetById(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The name of the Category should be at least 6 characters");
                throw new HttpResponseException(errResponse);
            }

            var entity = this.categoryRepository.Get(id);

            var model = new CategoryFullModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Places = (
                from placeEntity in entity.Places
                select new PlaceModel()
                {
                    Id = placeEntity.Id,
                    Name = placeEntity.Name,
                    Latitude = placeEntity.Latitude,
                    Longitude = placeEntity.Longitude,
                }).ToList()
            };
            return model;
        }

        [HttpPost]
        public HttpResponseMessage PostCategory(Category model)
        {
            if (model == null || model.Name == null || model.Name.Length < 6)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The name of the Category should be at least 6 characters");
                return errResponse;
            }

            var entity = this.categoryRepository.Add(model);

            var response =
                Request.CreateResponse(HttpStatusCode.Created, entity);

            response.Headers.Location = new Uri(Url.Link("DefaultApi",
                new { id = entity.Id }));
            return response;
        }

        //GET all


        //GET by Id
        //POST
        //PUT
        //DELETE
    }
}