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

namespace TV_program.UnitTests.Repos
{
    [TestFixture]
    [Category("Integration")]
    public class UserRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllUsersTest()
        {
            using var context = DbContextFactory.CreateDbContext();
            var user = new UserEntity[]
            {
                new UserEntity()
                {
                    Username = "Анастасия",
                    Email = "Anast012@mail.ru",
                    PhoneNumber = "89507765439",
                    Code = "FH1PN",
                    Registration = new DateTime(2022, 10, 12),
                    LastEntry = new DateTime(2023, 5, 25),
                    PasswordHash = "aliq12afr57",
                    ExternalId = Guid.NewGuid()
                },
                new UserEntity()
                {
                    Username = "Александр",
                    Email = "aLEX5@mail.ru",
                    PhoneNumber = "89507715500",
                    Code = "FQK4A",
                    Registration = new DateTime(2021, 6, 17),
                    LastEntry = new DateTime(2023, 4, 5),
                    PasswordHash = "afqwr24fvb6",
                    ExternalId = Guid.NewGuid()
                },
            };
            context.User.AddRange(user);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUser = repository.GetAll();

            //assert        
            actualUser.Should().BeEquivalentTo(user);
        }
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
        public void GetAllUsersWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Username = "Анастасия",
                Email = "Anast012@mail.ru",
                PhoneNumber = "89507765439",
                Code = "FH1PN",
                Registration = new DateTime(2022, 10, 12),
                LastEntry = new DateTime(2023, 5, 25),
                PasswordHash = "aliq12afr57",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Username = "Александр",
                Email = "aLEX5@mail.ru",
                PhoneNumber = "89507715500",
                Code = "FQK4A",
                Registration = new DateTime(2021, 6, 17),
                LastEntry = new DateTime(2023, 4, 5),
                PasswordHash = "afqwr24fvb6",
                ExternalId = Guid.NewGuid()
            },
            };
            context.User.AddRange(users);
            context.SaveChanges();
            //execute

            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUsers = repository.GetAll(x => x.Username == "Александр").ToArray();

            //assert
            actualUsers.Should().BeEquivalentTo(users.Where(x => x.Username == "Александр"));
        }
        [Test]
        public void SaveNewUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            //execute

            var user = new UserEntity()
            {
                Username = "Вадим",
                Email = "VAdim12@mail.ru",
                PhoneNumber = "89516716510",
                Code = "RT1NM",
                Registration = new DateTime(2023, 2, 4),
                LastEntry = new DateTime(2023, 5, 15),
                PasswordHash = "wtgzv12ey",
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Save(user);

            //assert
            var actualUser = context.User.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.Id)
                                                                       .Excluding(x => x.ModificationTime)
                                                                       .Excluding(x => x.CreationTime)
                                                                       .Excluding(x => x.ExternalId));
            actualUser.Id.Should().NotBe(default);
            actualUser.ModificationTime.Should().NotBe(default);
            actualUser.CreationTime.Should().NotBe(default);
            actualUser.ExternalId.Should().NotBe(Guid.Empty);
        }
        [Test]
        public void UpdateUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var user = new UserEntity()
            {
                Username = "Стас",
                Email = "Stas67@mail.ru",
                PhoneNumber = "89606006510",
                Code = "XVFJ2",
                Registration = new DateTime(2022, 1, 1),
                LastEntry = new DateTime(2022, 1, 13),
                PasswordHash = "afsagy12",
                ExternalId = Guid.NewGuid()
            };
            context.User.Add(user);
            context.SaveChanges();

            //execute

            user.Username = "Дмитрий";
            user.Email = "DmItRiY54@mail.ru";
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Save(user);

            //assert
            var actualUser = context.User.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user);
        }
        [Test]
        public void DeleteUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var user = new UserEntity()
            {
                Username = "Вадим",
                Email = "VAdim12@mail.ru",
                PhoneNumber = "89516716510",
                Code = "RT1NM",
                Registration = new DateTime(2023, 2, 4),
                LastEntry = new DateTime(2023, 5, 15),
                PasswordHash = "wtgzv12ey",
                ExternalId = Guid.NewGuid()
            };
            context.User.Add(user);
            context.SaveChanges();

            //execute

            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Delete(user);

            //assert
            context.User.Count().Should().Be(0);
        }
        [Test]
        public void GetByIdTest_PositiveCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Username = "Анастасия",
                Email = "Anast012@mail.ru",
                PhoneNumber = "89507765439",
                Code = "FH1PN",
                Registration = new DateTime(2022, 10, 12),
                LastEntry = new DateTime(2023, 5, 25),
                PasswordHash = "aliq12afr57",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Username = "Александр",
                Email = "aLEX5@mail.ru",
                PhoneNumber = "89507715500",
                Code = "FQK4A",
                Registration = new DateTime(2021, 6, 17),
                LastEntry = new DateTime(2023, 4, 5),
                PasswordHash = "afqwr24fvb6",
                ExternalId = Guid.NewGuid()
            },
            };
            context.User.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUser = repository.GetById(users[0].Id);

            //assert
            actualUser.Should().BeEquivalentTo(users[0]);
        }
        [Test]
        public void GetByIdTest_NegativeCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Username = "Анастасия",
                Email = "Anast012@mail.ru",
                PhoneNumber = "89507765439",
                Code = "FH1PN",
                Registration = new DateTime(2022, 10, 12),
                LastEntry = new DateTime(2023, 5, 25),
                PasswordHash = "aliq12afr57",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Username = "Александр",
                Email = "aLEX5@mail.ru",
                PhoneNumber = "89507715500",
                Code = "FQK4A",
                Registration = new DateTime(2021, 6, 17),
                LastEntry = new DateTime(2023, 4, 5),
                PasswordHash = "afqwr24fvb6",
                ExternalId = Guid.NewGuid()
            },
            };
            context.User.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUser = repository.GetById(users[users.Length - 1].Id + 1);

            //assert
            actualUser.Should().BeNull();
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
                context.User.RemoveRange(context.User);
                context.SaveChanges();
            }
        }
    }
}