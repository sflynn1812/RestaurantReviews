using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestarauntReviews.Controllers;
using RestarauntReviews.Service;
using RestarauntReviews.Service.Interface;
using RestaurantReviews.DAL.DTO;
using System.Collections.Generic;

namespace RestarauntReviews.Test
{
    [TestClass]
    public class RestaurantReviews
    {
        [TestMethod]
        public void RestaurantReviewService_GetRestaraunts()
        {
            //arrange
            var list = new List<Restaurant>();
            list.Add(new Restaurant() { BusinessName = "Tai Pei", PriceRatings = "Economical", RestaurantId = 1 });
            var moq = new Moq.Mock<IRestaurantReviewService>();
            object p = moq.Setup((a) => a.GetRestaraunts(It.IsAny<string>())).Returns(list);

            //act
            var controller = new RestaurantReviewsController(null, moq.Object);
            var restaurants = (List<Restaurant>)controller.GetRestaurants("Pittsburgh");

            //assert
            Assert.AreEqual(1, restaurants.Count);
        }

        [TestMethod]
        public void RestaurantReviewService_GetReview()
        {
            //arrange
            var list = new List<Review>();
            list.Add(new Review() { RatingScore = "1", ReviewDescription = "Delicious!", ReviewId = 1 });
            var moq = new Moq.Mock<IRestaurantReviewService>();
            object p = moq.Setup((a) => a.GetReviews(It.IsAny<string>())).Returns(list);

            //act
            var controller = new RestaurantReviewsController(null, moq.Object);
            var reviews = (List<Review>)controller.GetReviews("testuser");

            //assert
            Assert.AreEqual(1, reviews.Count);
        }

        [TestMethod]
        public void RestaurantReviewService_AddReview()
        {
            //arrange
            var review = new Review() { RatingScore = "1", ReviewDescription = "Delicious!", ReviewId = 1 };
            var moq = new Moq.Mock<IRestaurantReviewService>();
            object p = moq.Setup((a) => a.AddReview(review)).Returns(200);

            //act
            var controller = new RestaurantReviewsController(null, moq.Object);
            var result = controller.AddReview(review);

            //assert
            Assert.AreEqual(200, result);
        }

        [TestMethod]
        public void RestaurantReviewService_DeleteReview()
        {
            //arrange
            var moq = new Moq.Mock<IRestaurantReviewService>();
            object p = moq.Setup((a) => a.DeleteReview(1)).Returns(200);

            //act
            var controller = new RestaurantReviewsController(null, moq.Object);
            var result = controller.DeleteReview(1);

            //assert
            Assert.AreEqual(200, result);
        }

        [TestMethod]
        public void RestaurantReviewService_AddRestaurant()
        {
            //arrange
            var restaurant = new Restaurant() { BusinessName = "Burgatory", PriceRatings = "2", RestaurantId = 2  };
            var moq = new Moq.Mock<IRestaurantReviewService>();
            object p = moq.Setup((a) => a.AddRestaurant(restaurant)).Returns(200);

            //act
            var controller = new RestaurantReviewsController(null, moq.Object);
            var result = controller.AddRestaurant(restaurant);

            //assert
            Assert.AreEqual(200, result);
        }
    }
}

