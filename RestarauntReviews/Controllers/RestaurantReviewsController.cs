﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestarauntReviews.Service.Interface;
using RestaurantReviews.DAL.DTO;
using System;
using System.Collections.Generic;

namespace RestarauntReviews.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RestaurantReviewsController : ControllerBase
    {
        private readonly ILogger<RestaurantReviewsController> logger;
        private IRestaurantReviewService service;
        public RestaurantReviewsController(ILogger<RestaurantReviewsController> _logger, IRestaurantReviewService _service)
        {
            logger = _logger;
            service = _service;
        }

        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants([FromBody] string city)
        {
            try
            {
                return service.GetRestaraunts(city);
            } 
            catch (Exception ex)
            {
                logger.LogError("Error in GetRestaurants by City:" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);

                throw(ex);
            }

            
        }

        [HttpGet]
        public IEnumerable<Review> GetReviews([FromBody] string username)
        {
            try
            {
                return service.GetReviews(username);
            }
            catch (Exception ex)
            {
                logger.LogError("Error in GetReviews by username:" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);

                throw (ex);
            }


        }

        [HttpPost]
        public int AddReview([FromBody] Review review)
        {
            try
            {
                return service.AddReview(review);
            }
            catch (Exception ex)
            {
                logger.LogError("Error in AddReview:" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
                throw (ex);
            }
        }

        [HttpPost]
        public int DeleteReview([FromBody] int reviewId)
        {
            try
            {
                return service.DeleteReview(reviewId);
            }
            catch (Exception ex)
            {
                logger.LogError("Error in DeleteReview:" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
                throw (ex);
            }
        }

        [HttpPost]
        public int AddRestaurant([FromBody] Restaurant restaraunt)
        {
            try
            {
                return service.AddRestaurant(restaraunt);
            }
            catch (Exception ex)
            {
                logger.LogError("Error in AddRestaurant:" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
                throw (ex);
            }
        }
    }
}
