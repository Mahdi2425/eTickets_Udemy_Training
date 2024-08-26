using eTickets.Data.Enums;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using static System.Net.WebRequestMethods;

namespace eTickets.Data
{
    public class AppDbInitilizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var Context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                Context.Database.EnsureCreated();

                if (!Context.Cinemas.Any())
                {
                    Context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {

                            Name="Kourosh",
                            CinemaLogoURL="https://th.bing.com/th/id/OIP.3b5xHJFeiHTs88F8tL0wNQHaHa?w=180&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                            Description="The largest and most modern cineplex in Iran, located in the Kourosh Complex. It has 14 halls named after famous old Iranian cinemas."
                        },
                        new Cinema()
                        {

                            Name="Mellat",
                            CinemaLogoURL="https://th.bing.com/th/id/OIG2.lV1HMPTj5HBNTy0Tnw4z?w=1024&h=1024&rs=1&pid=ImgDetMain",
                            Description="Located in Mellat Park, this cineplex offers four movie halls, a performance hall, exhibition areas, restaurants, and cafes."
                        },
                        new Cinema()
                        {

                            Name="Charsou",
                            CinemaLogoURL="https://th.bing.com/th/id/OLC.NICvnXya09P5FA480x360?&rs=1&pid=ImgDetMain",
                            Description="A modern media mall with five movie halls equipped with the latest audiovisual facilities. It also offers a place for live music and galleries."
                        },
                        new Cinema()
                        {

                            Name="Farhang",
                            CinemaLogoURL="https://th.bing.com/th/id/OIG4.hfWeVmTZ5g_tNN69HaRL?pid=ImgGn",
                            Description="An arthouse theatre located on Shariati Street, known for its nostalgic atmosphere and display of old school film equipment."
                        },
                        new Cinema()
                        {

                            Name="Pardis Gholhak",
                            CinemaLogoURL="https://th.bing.com/th/id/R.697f93bbaaa067470132fd06ee9ce2d0?rik=xaxglw9bD6mO0A&riu=http%3a%2f%2fgharighi.com%2fwp-content%2fuploads%2f2016%2f03%2fRedesign_OriginalLogo.jpg&ehk=83mXzAhfMDvxid2LAm8uVUzOLcpCH4wcgwYIC536iU4%3d&risl=&pid=ImgRaw&r=0",
                            Description="Known for screening old and new Hollywood blockbusters and animations. It requires a small membership fee."
                        },
                        new Cinema()
                        {

                            Name="Iran Mall",
                            CinemaLogoURL="https://th.bing.com/th/id/OIP.guGaPdYU7XpV3lDPZ3iv6QHaHa?rs=1&pid=ImgDetMain",
                            Description="Iran Mall Cineplex is the most advanced movie theater in the country; with twelve different auditoriums, the huge complex provides the finest audio-visual quality for its audiences with the help of world class picture and sound projection systems. "
                        }
                    });
                    Context.SaveChanges();

                }
                if (!Context.Actors.Any())
                {
                    Context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName="Mohsen Tanabandeh",
                            PictureProfileURL="https://static.cdn.asset.cinematicket.org/media/cache/32/d3/32d3a5e492e99538b15f13e5b70cdf1b.webp",
                            Bio="He is an Actor,Writer and Producer.Born in Tehran on April 1977 also he is popular in Iran"
                        },
                        new Actor()
                        {
                            FullName="Fatemeh Motamedaria",
                            PictureProfileURL="https://static.cdn.asset.cinematicket.org/media/cache/71/e3/71e34062d0b2abbef27547cd3830a5c3.webp",
                            Bio="She is an Actor.Born in Tehran on October 1961 also she is a great mother and husband"
                        },
                        new Actor()
                        {
                            FullName="Pejman Jamshidi",
                            PictureProfileURL="https://static.cdn.asset.cinematicket.org/media/cache/c0/79/c0796746567c4d4488cc4b18d82a41d3.webp",
                            Bio="Pejman Jamshidi (born September 1, 1977) is an Iranian actor and former footballer. His performances in the films The Misunderstanding (2018), Shishlik (2021) and Grassland (2022), A Relic of the South (2023) earned him Crystal Simorgh nominations."
                        },
                        new Actor()
                        {
                            FullName="Sam Derakhshani",
                            PictureProfileURL="https://th.bing.com/th/id/OIP.v7Z8iXbwbbLjY2vnOazlJgAAAA?rs=1&pid=ImgDetMain",
                            Bio="Sam Derakhshani was born on 22 July 1975. He is an actor, known for The Good, the Bad, the Corny (2017), The Good, the Bad, the Corny 2 (2020) and Davinchiz (2023)."
                        },
                        new Actor()
                        {
                            FullName="Ahmad Mehranfar",
                            PictureProfileURL="https://th.bing.com/th/id/R.220d3e97695b077b897fee3ebca5c8ce?rik=EGdwCx1K6om%2f5g&pid=ImgRaw&r=0",
                            Bio="Ahmad Mehranfar(born May 31, 1975) is an Iranian actor. He is best known for his role as Arastou Amel in Capital."
                        },
                        new Actor()
                        {
                            FullName="Shabnam Moghaddami",
                            PictureProfileURL="https://th.bing.com/th/id/R.2af082e134c6ff7f0fece6afcdf6f0b2?rik=K8Zt55Uqsii3FA&pid=ImgRaw&r=0",
                            Bio="Shabnam Moghaddami is an Iranian actress and narrator known for her ability to depict characters with genuine depth and authenticity, breathing life into various facets of their personalities.. Some of her notable film credits include Kissing the Moon-Like Face (2012), Today (2014), Breath (2016), Spare (2016), Life and a Day (2016), Abba Jaan (2017), Don't Be Embarassed (2018), andWhen the Moon Was Full (2019)."
                        },
                        new Actor()
                        {
                            FullName="Abbas Jamshidifar",
                            PictureProfileURL="https://th.bing.com/th/id/R.e416d0ed6280af7043ea2ef84f334b84?rik=xKLMOzRU8k9%2fRA&pid=ImgRaw&r=0",
                            Bio="Abbas Jamshidifar is known for Tornado (2019), Mortal Wound (2021) and Alligator Blood (2024).\r\n"
                        },
                        new Actor()
                        {
                            FullName="Javad Ezati",
                            PictureProfileURL="https://th.bing.com/th/id/OIP.dt3rUFsKYvcXJQuOe-GJQwAAAA?rs=1&pid=ImgDetMain",
                            Bio="Mohammad Javad Ezzati is an Iranian actor and director. He has received critical acclaim for his work in a wide range of genres. As of 2019, Ezzati's starring films have grossed 150 billion toman and accumulated more than 18 million tickets, making him the highest-grossing actor in Iran. "
                        },
                        new Actor()
                        {
                            FullName="Saeed Aghakhani",
                            PictureProfileURL="https://th.bing.com/th/id/OIP.y6_BDropdRIjoUKpzOkxoQHaHa?rs=1&pid=ImgDetMain",
                            Bio="Saeed Aghakhani was born on February 23, 1972 in Bijar, Iran. He is an actor and director, known for The Long Farewell (2015), Noon Khe (2019) and It Turned Into Blood (2020)."
                        },
                        new Actor()
                        {
                            FullName="Shahab Hosseini",
                            PictureProfileURL= "https://th.bing.com/th/id/R.dc52ee2bfc6f717238c3f3ae948dc2c9?rik=GD0IvSdnqpP60A&pid=ImgRaw&r=0",
                            Bio="Shahab Hosseini was born on February 3, 1974 in Tehran, Iran. "
                        },
                        new Actor()
                        {
                            FullName="Parsa Pirouzfar",
                            PictureProfileURL="https://th.bing.com/th/id/OIP.BnpsYplWPfR-QnN1KTFnHAAAAA?rs=1&pid=ImgDetMain",
                            Bio="Parsa Pirouzfar was born on 13 September 1972 in Tehran, Iran. He is an Iranian actor; theater director, acting teacher, playwright, translator and painter. "
                        },
                        new Actor()
                        {
                            FullName="Hande Erçel",
                            PictureProfileURL="https://th.bing.com/th/id/R.b3c58e253b8d860ea998d4c39f94b362?rik=G7mgCyQEzl6fog&pid=ImgRaw&r=0",
                            Bio="Hande Erçel is a distinguished actress known for her roles in 'The Daughters of the Sun' (2015), 'Hayat: Love Without Words' (2016), 'Halka' (2019), Love Is in the Air (2020) and 'Another Love' (2023).Raised in Turkey, Hande pursued her education at the 'Mimar Sinan Fine Arts University. "

                        },
                        new Actor()
                        {
                            FullName="Elnaz Shakerdoost",
                            PictureProfileURL="https://th.bing.com/th/id/OIP.Y5AjJqcXH-cxodCnSisQmQHaHa?w=720&h=720&rs=1&pid=ImgDetMain",
                            Bio="Elnaz Shakerdoost is an Iranian actress, who has gained success inside Iran. Shakerdoost was born in Tehran."
                        },
                        new Actor()
                        {
                            FullName="Navid Pourfaraj",
                            PictureProfileURL="https://th.bing.com/th/id/OIP.HITJ4hurzg2v5Q-7evidbQHaHa?rs=1&pid=ImgDetMain",
                            Bio="Navid Pourfaraj was born on 22 April 1988 in Kermanshah, Iran. He is an actor, known for Sheeple (2018), Zalava (2021) and Bone Marrow (2020)."
                        }
                    });
                    Context.SaveChanges();

                }
                if (!Context.Producers.Any())
                {
                    Context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName="Hamidreza Azarang",
                            PictureProfileURL ="https://th.bing.com/th/id/OIP.niSum3KkWPHSWNGe-t7ejAAAAA?rs=1&pid=ImgDetMain",
                            Bio="Hamid Reza Azarang or Hamid-Reza Azarang is an Iranian actor, director and screenwriter.Born in Tehran 1972.",
                        },
                        new Producer()
                        {
                            FullName="Masoud Atyabi",
                            PictureProfileURL ="https://th.bing.com/th/id/OIP.ehJU1unreSsVuT1wUHAl2wHaHa?rs=1&pid=ImgDetMain",
                            Bio="Masoud Atyabi is known for Texas (2018), Father's Secrets (2014) and Solitary (2023).",

                        },
                        new Producer()
                        {
                            FullName="Reza Maghsoodi",
                            PictureProfileURL ="https://th.bing.com/th/id/OIP.Ka9WnnBFI-UGMsIYMdxvvAAAAA?rs=1&pid=ImgDetMain",
                            Bio="Reza Maghsoodi is known for Don't Be Embarassed (2018), Doping (2020) and Leily Is with Me (1996).",
                        },
                        new Producer()
                        {
                            FullName="Javad Ezati",
                            PictureProfileURL ="https://th.bing.com/th/id/OIP.qrbyToG1HymkB82cR8vxcAHaHa?w=168&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                            Bio="Mohammad Javad Ezzati is an Iranian actor and director. He has received critical acclaim for his work in a wide range of genres. As of 2019, Ezzati's starring films have grossed 150 billion toman and accumulated more than 18 million tickets, making him the highest-grossing actor in Iran.",
                        },
                        new Producer()
                        {
                            FullName="Hasan Fathi",
                            PictureProfileURL ="https://th.bing.com/th/id/OIP.VsCAhdn5Y8tPxyzSa4JgwAAAAA?w=166&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                            Bio="Hasan Fathi is a Director,Writer and Producer known for Shahrzad (2015), The Tenth Night (2002) and Jeyran (2022).",
                        },
                        new Producer()
                        {
                            FullName="Morteza Alizadeh",
                            PictureProfileURL ="https://deeplor.s3.us-west-2.amazonaws.com/matting_original/2024/08/30/8d8771b931b64168b43ddf85c4feef51.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Date=20240830T143558Z&X-Amz-SignedHeaders=host&X-Amz-Expires=10800&X-Amz-Credential=AKIAROYXHKZUSZONTWIG%2F20240830%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Signature=80dd0e4bbbd635d9d410341145c23ac84df89fde71676e021494421235cf37e3",
                            Bio="Morteza Alizadeh is known for Bodiless so he is new but he is professional",
                        }
                    });
                    Context.SaveChanges();
                }
                if (!Context.Movies.Any())
                {
                    Context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name="Texas 3",
                            Description="Begins after the story of the statues containing cocaine in the previous episode.",
                            price=75.32,
                            ImageMovieURL="https://static.cdn.asset.cinematicket.org/media/cache/ab/7d/ab7dc69cf254d5e3ac4b87c63988c505.webp",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(29),
                            CinemaId = 3,
                            ProducerId = 2,
                            movieCategory = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name="Once upen a time in Abadan",
                            Description="On the last they of the year the five-member family of Mosayeb is busy shopping for Eid ...",
                            price=60.5,
                            ImageMovieURL="https://static.cdn.asset.cinematicket.org/media/cache/34/d8/34d8edd7b8135fcb9ab961664d5cb8db.webp",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(25),
                            CinemaId = 4,
                            ProducerId = 1,
                            movieCategory = MovieCategory.Adventure
                        },
                        new Movie()
                        {
                            Name="Don't be Embarassed 2",
                            Description="This movie narrates the life story of a couple who lives in a vilage ...",
                            price=65.48,
                            ImageMovieURL="https://static.cdn.asset.cinematicket.org/media/cache/41/91/41919ae0275752f6bd03aed514c6b393.webp",
                            StartDate=DateTime.Now.AddDays(3),
                            EndDate=DateTime.Now.AddDays(17),
                            CinemaId = 5,
                            ProducerId = 3,
                            movieCategory = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name="Alligator Blood",
                            Description="A wounded person who has lost his whole life and has nothing to lose wants to take big risks.",
                            price=63.22,
                            ImageMovieURL="https://static.cdn.asset.cinematicket.org/media/cache/48/1d/481d54a465df7e6678b78f948c71db0c.webp",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(22),
                            CinemaId = 6,
                            ProducerId = 4,
                            movieCategory = MovieCategory.Adventure
                        },
                        new Movie()
                        {
                            Name="Intoxicated by Love",
                            Description="The story of Rumi and Shams and the great influence of Shams over him in his life, his poetry and his love for God.",
                            price=61,
                            ImageMovieURL="https://static.cdn.asset.cinematicket.org/media/cache/73/62/7362a75bf0ddfedb0628eded6e02284b.webp",
                            StartDate=DateTime.Now.AddDays(10),
                            EndDate=DateTime.Now.AddDays(20),
                            CinemaId = 2,
                            ProducerId = 5,
                            movieCategory = MovieCategory.History
                        },
                        new Movie()
                        {
                            Name="Bodiless",
                            Description="The film refers to a famous criminal case of the 90s...",
                            price=58.75,
                            ImageMovieURL="https://static.cdn.asset.filimo.com/flmt/mov_148573_183474.jpg?width=300&quality=85&secret=WXlwPhvBzpT5OdFMt6S7rQ",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(36),
                            CinemaId = 1,
                            ProducerId = 6,
                            movieCategory = MovieCategory.Drama
                        }

                    });
                    Context.SaveChanges();

                }
                if (!Context.Actors_Movies.Any())
                {
                    Context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3

                        },
                        new Actor_Movie()
                        {
                            ActorId = 6,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 7,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 8,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 9,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 10,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 11,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 12,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 13,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 14,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        }





                    });
                    Context.SaveChanges();

                }
            }
        }
        public static async Task SeedUsersandRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var appuseremail = "admin@etickets.com";
                var appUser = await userManager.FindByEmailAsync(appuseremail);
                if (appUser == null)
                {
                    var newappuser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = appuseremail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newappuser, "coded1234@");
                    await userManager.AddToRoleAsync(newappuser, UserRoles.Admin);
                }

            }

        }
    }
}
