using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.DataAccess;
using TV_program.DataAccess.Entities;
using FluentAssertions;
using NUnit.Framework;
using TV_program.Repository;
using System.Threading.Channels;

namespace TV_program.UnitTests.Repos
{
    [TestFixture]
    [Category("Integration")]
    public class TV_programRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllTVShowsTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var channel = new ChannelEntity()
            {
                Title = "СТС",
                ExternalId = Guid.NewGuid()
            };
            context.Channel.Add(channel);
            context.SaveChanges();

            var tvShow = new TVShowEntity[]
            {
            new TVShowEntity()
            {
                IdChannel=channel.Id,
                Title="Жених напрокат",
                Desctiption="Романтическая комедия является экранизацией романа Эмили Гриффин 'Жених напрокат'",
                DurationInMinutes=140,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(11, 0, 0),
                ExternalId = Guid.NewGuid()
            },
            new TVShowEntity()
            {
                IdChannel=channel.Id,
                Title="Новый Человек-паук",
                Desctiption="«Новый Человек-паук» (2012) — перезапуск трилогии Сэма Рэйми, ставший четвертым фильмом о персонаже Marvel Comics Человеке-пауке.",
                DurationInMinutes=165,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(15, 15, 0),
                ExternalId = Guid.NewGuid()
            },
            };
            context.TVShow.AddRange(tvShow);
            context.SaveChanges();

            //execute
            var repository = new Repository<TVShowEntity>(DbContextFactory);
            var actualTVShow = repository.GetAll();

            //assert        
            actualTVShow.Should().BeEquivalentTo(tvShow, options => options.Excluding(x => x.Channel));
        }
        [Test]
        public void GetAllTVShowsWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var channel = new ChannelEntity()
            {
                Title = "СТС",
                ExternalId = Guid.NewGuid()
            };
            context.Channel.Add(channel);
            context.SaveChanges();

            var tvShow = new TVShowEntity[]
            {
            new TVShowEntity()
            {
                IdChannel=channel.Id,
                Title="Жених напрокат",
                Desctiption="Романтическая комедия является экранизацией романа Эмили Гриффин 'Жених напрокат'",
                DurationInMinutes=140,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(11, 0, 0),
                ExternalId = Guid.NewGuid()
            },
            new TVShowEntity()
            {
                IdChannel=channel.Id,
                Title="Новый Человек-паук",
                Desctiption="«Новый Человек-паук» (2012) — перезапуск трилогии Сэма Рэйми, ставший четвертым фильмом о персонаже Marvel Comics Человеке-пауке.",
                DurationInMinutes=165,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(15, 15, 0),
                ExternalId = Guid.NewGuid()
            },
            };

            context.TVShow.AddRange(tvShow);
            context.SaveChanges();
            //execute

            var repository = new Repository<TVShowEntity>(DbContextFactory);
            var actualTVShow = repository.GetAll(x => x.Title == "Новый Человек-паук").ToArray();

            //assert
            actualTVShow.Should().BeEquivalentTo(tvShow.Where(x => x.Title == "Новый Человек-паук"), options => options.Excluding(x => x.Channel));
        }

        [Test]
        public void SaveNewTVShowsTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            //execute
            var channel = new ChannelEntity()
            {
                Title = "СТС",
                ExternalId = Guid.NewGuid()
            };
            context.Channel.Add(channel);
            context.SaveChanges();

            var my_show = new TVShowEntity()
            {
                IdChannel = channel.Id,
                Title = "Новый Человек-паук",
                Desctiption = "«Новый Человек-паук» (2012) — перезапуск трилогии Сэма Рэйми, ставший четвертым фильмом о персонаже Marvel Comics Человеке-пауке.",
                DurationInMinutes = 165,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(15, 15, 0),
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<TVShowEntity>(DbContextFactory);
            repository.Save(my_show);

            //assert
            var actualTVShow = context.TVShow.SingleOrDefault();
            actualTVShow.Should().BeEquivalentTo(my_show, options => options.Excluding(x => x.Id)
                                                                            .Excluding(x => x.ModificationTime)
                                                                            .Excluding(x => x.CreationTime)
                                                                            .Excluding(x => x.ExternalId)
                                                                            .Excluding(x => x.Channel));
            actualTVShow.Id.Should().NotBe(default);
            actualTVShow.ModificationTime.Should().NotBe(default);
            actualTVShow.CreationTime.Should().NotBe(default);
            actualTVShow.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateTVShowsTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var channel = new ChannelEntity()
            {
                Title = "СТС",
                ExternalId = Guid.NewGuid()
            };
            context.Channel.Add(channel);
            context.SaveChanges();

            var my_show = new TVShowEntity()
            {
                IdChannel = channel.Id,
                Title = "Новый Человек-паук",
                Desctiption = "«Новый Человек-паук» (2012) — перезапуск трилогии Сэма Рэйми, ставший четвертым фильмом о персонаже Marvel Comics Человеке-пауке.",
                DurationInMinutes = 165,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(15, 15, 0),
                ExternalId = Guid.NewGuid()
            };
            context.TVShow.Add(my_show);
            context.SaveChanges();

            //execute

            my_show.Title = "Поехавшая";
            my_show.DurationInMinutes = 170;
            var repository = new Repository<TVShowEntity>(DbContextFactory);
            repository.Save(my_show);

            //assert
            var actualTVShow = context.TVShow.SingleOrDefault(my_show);
            actualTVShow.Should().BeEquivalentTo(my_show, options => options.Excluding(x => x.Channel));
        }

        [Test]
        public void DeleteTVShowsTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var channel = new ChannelEntity()
            {
                Title = "СТС",
                ExternalId = Guid.NewGuid()
            };
            context.Channel.Add(channel);
            context.SaveChanges();

            var my_show = new TVShowEntity()
            {
                IdChannel = channel.Id,
                Title = "Новый Человек-паук",
                Desctiption = "«Новый Человек-паук» (2012) — перезапуск трилогии Сэма Рэйми, ставший четвертым фильмом о персонаже Marvel Comics Человеке-пауке.",
                DurationInMinutes = 165,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(15, 15, 0),
                ExternalId = Guid.NewGuid()
            };
            context.TVShow.Add(my_show);
            context.SaveChanges();

            //execute

            var repository = new Repository<TVShowEntity>(DbContextFactory);
            repository.Delete(my_show);

            //assert
            context.TVShow.Count().Should().Be(0);
        }
        [Test]
        public void GetByIdTest_PositiveCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var channel = new ChannelEntity()
            {
                Title = "СТС",
                ExternalId = Guid.NewGuid()
            };
            context.Channel.Add(channel);
            context.SaveChanges();

            var tvShow = new TVShowEntity[]
            {
            new TVShowEntity()
            {
                IdChannel=channel.Id,
                Title="Жених напрокат",
                Desctiption="Романтическая комедия является экранизацией романа Эмили Гриффин 'Жених напрокат'",
                DurationInMinutes=140,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(11, 0, 0),
                ExternalId = Guid.NewGuid()
            },
            new TVShowEntity()
            {
                IdChannel=channel.Id,
                Title="Новый Человек-паук",
                Desctiption="«Новый Человек-паук» (2012) — перезапуск трилогии Сэма Рэйми, ставший четвертым фильмом о персонаже Marvel Comics Человеке-пауке.",
                DurationInMinutes=165,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(15, 15, 0),
                ExternalId = Guid.NewGuid()
            },
            };
            context.TVShow.AddRange(tvShow);
            context.SaveChanges();

            //execute
            var repository = new Repository<TVShowEntity>(DbContextFactory);
            var actualTVShow = repository.GetById(tvShow[0].Id);

            //assert
            actualTVShow.Should().BeEquivalentTo(tvShow[0], options => options.Excluding(x => x.Channel));
        }
        [Test]
        public void GetByIdTest_NegativeCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var channel = new ChannelEntity()
            {
                Title = "СТС",
                ExternalId = Guid.NewGuid()
            };
            context.Channel.Add(channel);
            context.SaveChanges();

            var tvShow = new TVShowEntity[]
            {
            new TVShowEntity()
            {
                IdChannel=channel.Id,
                Title="Жених напрокат",
                Desctiption="Романтическая комедия является экранизацией романа Эмили Гриффин 'Жених напрокат'",
                DurationInMinutes=140,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(11, 0, 0),
                ExternalId = Guid.NewGuid()
            },
            new TVShowEntity()
            {
                IdChannel=channel.Id,
                Title="Новый Человек-паук",
                Desctiption="«Новый Человек-паук» (2012) — перезапуск трилогии Сэма Рэйми, ставший четвертым фильмом о персонаже Marvel Comics Человеке-пауке.",
                DurationInMinutes=165,
                BroadcastDate = new DateTime(2023, 11, 22),
                BroadcastTime = new TimeSpan(15, 15, 0),
                ExternalId = Guid.NewGuid()
            },
            };
            context.TVShow.AddRange(tvShow);
            context.SaveChanges();

            //execute
            var repository = new Repository<TVShowEntity>(DbContextFactory);
            var actualTVShow = repository.GetById(tvShow[tvShow.Length - 1].Id + 1);

            //assert
            actualTVShow.Should().BeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            using (var context = DbContextFactory.CreateDbContext())
            {
                context.TVShow.RemoveRange(context.TVShow);
                context.Channel.RemoveRange(context.Channel);
                context.SaveChanges();
            }
        }
    }
}
