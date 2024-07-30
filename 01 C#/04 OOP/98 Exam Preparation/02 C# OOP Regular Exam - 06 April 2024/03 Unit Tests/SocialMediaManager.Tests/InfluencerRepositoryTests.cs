using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        Influencer influencer;
        InfluencerRepository influencers;

        [SetUp]
        public void Setup()
        {
            influencer = new Influencer("username", 10);
            influencers = new InfluencerRepository();
        }

        [Test]
        public void ConstructorsShouldCreateObjects()
        {
            Assert.IsNotNull(influencer);
            Assert.IsNotNull(influencers);

            Assert.That(influencer.Username, Is.EqualTo("username"));
            Assert.That(influencer.Followers, Is.EqualTo(10));
            Assert.That(influencers.Influencers.Count, Is.EqualTo(0));
        }

        [Test]
        public void RegisterInfluencerMethodShouldThrowExceptionWhenValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => influencers.RegisterInfluencer(null));
        }

        [Test]
        public void RegisterInfluencerMethodShouldThrowExceptionWhenInfluencerAlreadyExists()
        {
            influencers.RegisterInfluencer(influencer);

            Assert.Throws<InvalidOperationException>(() => influencers.RegisterInfluencer(influencer));
        }

        [Test]
        public void RegisterInfluencerMethodShouldWorkCorrectly()
        {
            string result = influencers.RegisterInfluencer(influencer);

            Assert.That(result, Is.EqualTo($"Successfully added influencer {influencer.Username} with {influencer.Followers}"));
            Assert.That(influencers.Influencers.Any(), Is.EqualTo(true));

            var retrievedInfluencer = influencers.Influencers.FirstOrDefault(x => x == influencer);

            Assert.That(retrievedInfluencer, Is.EqualTo(influencer));
        }

        [Test]
        public void RemoveInfluencerMethodShouldThrowExceptionWhenValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => influencers.RemoveInfluencer(null));
        }

        [Test]
        public void RemoveInfluencerMethodShouldReturnTrue()
        {
            influencers.RegisterInfluencer(influencer);

            var result = influencers.RemoveInfluencer(influencer.Username);

            Assert.True(result);
        }

        [Test]
        public void RemoveInfluencerMethodShouldReturnFalse()
        {
            var result = influencers.RemoveInfluencer(influencer.Username);
            Assert.False(result);
        }

        [Test]
        public void GetInfluencerWithMostFollowersMethodShouldReturnCorrectlyTheInfluencerWithMostFollowers()
        {
            Influencer influencer2 = new Influencer("username2", 9);
            Influencer influencer3 = new Influencer("username3", 11);
            Influencer influencer4 = new Influencer("username4", 8);

            influencers.RegisterInfluencer(influencer);
            influencers.RegisterInfluencer(influencer2);
            influencers.RegisterInfluencer(influencer3);
            influencers.RegisterInfluencer(influencer4);

            var result = influencers.GetInfluencerWithMostFollowers();

            Assert.That(result, Is.EqualTo(influencer3));
        }

        [Test]
        public void GetInfluencerMethodShouldReturnNull()
        {
            var result = influencers.GetInfluencer("test");

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetInfluencerMethodShouldReturnTheNeededInfluencer()
        {
            influencers.RegisterInfluencer(influencer);

            var result = influencers.GetInfluencer("username");

            Assert.That(result, Is.EqualTo(influencer));
        }
    }
}