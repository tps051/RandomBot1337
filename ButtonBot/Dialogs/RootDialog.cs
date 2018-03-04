using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Scorables;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.IO;


namespace ButtonBot.Dialogs
{
    [Serializable]
 
    public class RootDialog : IDialog<object>
    {
        private const string Weather = "Weather";
        private const string BredStories = "/b/Story";
        private const string HeroCard = "Hero card";
        private const string SigninCard = "Sign-in card";
        private const string AnimationCard = "Animation card";
        private const string VideoCard = "Video card";
        private const string AudioCard = "Audio card";
        private const string PicrandomCard = "Pic random";


        static string path = @"C:\\Users\\Ivan\\Downloads\\RandomBot1337\\ButtonBot\\json.json";
        static Story pasts;
        static List<Story> stories;
        
        private IEnumerable<string> options = new List<string> {BredStories, HeroCard, PicrandomCard, SigninCard, AnimationCard, VideoCard, AudioCard };
        public async Task StartAsync(IDialogContext context)
        {
            string str = File.ReadAllText(path);
            stories = new List<Story>();
            stories = JsonConvert.DeserializeObject<List<Story>>(str);
            Pasts();
            context.Wait(MessageReceivedAsync);
        }
        public static void Pasts()
        {
           Random rnd = new Random();
           int index = rnd.Next(stories.Count);
           pasts = stories[index];
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IActivity> result)
        {
            Attachment create = new HeroCard
            {
                Buttons = new List<CardAction>
                {
                    new CardAction
                    {
                        Value = Weather,
                        Text = Weather,
                        Title = Weather,
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Value = BredStories,
                        Text = BredStories,
                        Title = BredStories,
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Value = HeroCard,
                        Text = HeroCard,
                        Title = HeroCard,
                        Type = ActionTypes.ImBack
                    },
                     new CardAction
                    {
                        Value = PicrandomCard,
                        Text = PicrandomCard,
                        Title = PicrandomCard,
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Value = SigninCard,
                        Text = SigninCard,
                        Title = SigninCard,
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Value = AnimationCard,
                        Text = AnimationCard,
                        Title = AnimationCard,
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Value = VideoCard,
                        Text = VideoCard,
                        Title = VideoCard,
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Value = AudioCard,
                        Text = AudioCard,
                        Title = AudioCard,
                        Type = ActionTypes.ImBack
                    }
                }
            }.ToAttachment();
            IMessageActivity repl = context.MakeMessage();
            repl.Attachments.Add(create);
            await context.PostAsync(repl);
            IActivity selectedCard = await result;
            IMessageActivity message = context.MakeMessage();

            Attachment attachment = GetCard(selectedCard.AsMessageActivity().Text);
            message.Attachments.Add(attachment);

            await context.PostAsync(message);
            context.Wait(MessageReceivedAsync);
        }
    
        private static Attachment GetCard(string select)
        {

            switch (select)
            {
                case Weather:
                    return GetWeather();
                case BredStories:
                    return GetStory();
                case PicrandomCard:
                    return GetPicrandomCard();
                case HeroCard:
                    return GetHeroCard();
                case SigninCard:
                    return GetSigninCard();
                case AnimationCard:
                    return GetAnimationCard();
                case VideoCard:
                    return GetVideoCard();
                case AudioCard:
                    return GetAudioCard();

                default:
                    return GetHeroCard();
            }
        }
        //private static Attachment GetWeather()
        //{
        //    HeroCard heroCard = new HeroCard
        //    {
        //        Title = "Weather Today (Moscow)",
        //        Subtitle = "",
        //       // Text = Pasts()
        //    };
        //    return heroCard.ToAttachment();
        //}
        private static Attachment GetStory()
        {
            HeroCard heroCard = new HeroCard
            {
                Title = pasts.Header,
                Subtitle = "",
                Text = pasts.Text,
                 Buttons = new List<CardAction>
                {
                    new CardAction{
                        Value = BredStories,
                        Text = BredStories,
                        Title = BredStories,
                        Type = ActionTypes.ImBack
                    }
                }
            };
            return heroCard.ToAttachment();
        }
        private static Attachment GetHeroCard()
        {
            HeroCard heroCard = new HeroCard
            {
                Title = "w31c0m3!",
                Subtitle = "",
                Text = "",
                Images = new List<CardImage>
                {
                    new CardImage("https://pp.userapi.com/c623900/v623900617/a866b/vFxo15pmCio.jpg")
                },
                Buttons = new List<CardAction>
                {
                    new CardAction{
                        Value = PicrandomCard,
                        Text = PicrandomCard,
                        Title = PicrandomCard,
                        Type = ActionTypes.ImBack
                    }
                }
            };

            return heroCard.ToAttachment();
        }
            public static string Ran()
            {
                string[] urls =
                {
                    "https://pp.userapi.com/c629208/v629208845/19f01/wCdlYtgfKmo.jpg",
                    "https://pp.userapi.com/c621509/v621509748/644ec/nDTD4133wlU.jpg",
                    "https://pp.userapi.com/c638026/v638026508/32185/8_XieE2Fqbc.jpg",
                    "https://pp.userapi.com/c543101/v543101662/329d4/6OKPYwKDnRY.jpg",
                    "https://pp.userapi.com/c840422/v840422860/43037/huEyNJoHCqU.jpg",
                    "https://pp.userapi.com/c636324/v636324164/456e5/fhKIaVtEL7Q.jpg",
                    "https://pp.userapi.com/c841435/v841435457/6449f/R0VLvLeyQns.jpg",
                    "https://pp.userapi.com/c7006/v7006362/2ccaa/nkRR12uBev0.jpg",
                    "https://pp.userapi.com/c543106/v543106219/3a795/E_WU0hvJTAw.jpg",
                    "https://pp.userapi.com/c841430/v841430316/6b294/dR1rF0Ix64s.jpg",
                    "https://pp.userapi.com/c840431/v840431351/525a7/i8voIb-TygQ.jpg",
                    "https://pp.userapi.com/c834201/v834201258/b0ace/Dhuw6DOmFgc.jpg",
                    "https://2ch.pm/b/src/170539993/15184194611442.jpg"
                };
                Random rnd = new Random();
                int index = rnd.Next(urls.Length);
            return urls[index];
        }

        
           private static Attachment GetPicrandomCard()
          {
            HeroCard heroCard = new HeroCard
            {
                Title = "",
                Subtitle = "",
                Text = "",
                Images = new List<CardImage>
                  {
                      new CardImage(Ran())
                  },
                  Buttons = new List<CardAction>
                  {   
                      new CardAction
                      {
                          Value = PicrandomCard,
                          Text = PicrandomCard,
                          Title = PicrandomCard,
                          Type = ActionTypes.ImBack
                      }
                  }
              };

              return heroCard.ToAttachment();
          }
       


        private static Attachment GetSigninCard()
        {
            SigninCard signinCard = new SigninCard
            {
                Text = "BotFramework Sign-in Card",
                Buttons = new List<CardAction>
                {
                    new CardAction(ActionTypes.Signin, "Sign-in", value: "https://login.microsoftonline.com/"),
                    new CardAction
                    {
                        Value = "http://vk.com",
                        Title = "Open VK",
                        Type = ActionTypes.OpenUrl
                    },
                    new CardAction
                    {
                        Value = AnimationCard,
                        Text = AnimationCard,
                        Title = AnimationCard,
                        Type = ActionTypes.ImBack
                    }
                }
            };
            return signinCard.ToAttachment();
        }

        private static Attachment GetAnimationCard()
        {
            AnimationCard animationCard = new AnimationCard
            {
                Media = new List<MediaUrl>
                {
                    new MediaUrl("https://media.giphy.com/media/3oriNS5VULj8Ndn0TS/giphy.gif")

                },
                Buttons = new List<CardAction> { new CardAction
                    {
                        Value = VideoCard,
                        Text = VideoCard,
                        Title = VideoCard,
                        Type = ActionTypes.ImBack
                    } }
            };
            return animationCard.ToAttachment();
        }
 //Weather
        private static Attachment GetWeather()
        {
            HeroCard heroCard = new HeroCard
            {
                Title = "Weather Today (Moscow)",
                Subtitle = "",


            };
            return heroCard.ToAttachment();
        }

 // WEBMrandom
        public static string webm()
        {
            string[] webm =
            {
                   "https://2ch.pm/media/src/72722/14859224950100.webm",
                        "https://2ch.pm/media/src/72722/14862240863890.webm"
                };
            Random rnd = new Random();
            int index = rnd.Next(webm.Length);
            return webm[index];
        }
        private static Attachment GetVideoCard()
        {
            VideoCard videoCard = new VideoCard
            {
                Media = new List<MediaUrl>{
                    new MediaUrl(webm())
                },
                Buttons = new List<CardAction> { new CardAction
                    {
                        Value = AudioCard,
                        Text = AudioCard,
                        Title = AudioCard,
                        Type = ActionTypes.ImBack
                    } }
            };
            return videoCard.ToAttachment();
        }
// MUS THREAD random
        public static string mus()
        {
            string[] mus =
            {
                // noname 
                //   "https://2ch.pm/mu/src/1490623/15183754652733.mp4",
                //lil peep - spotlight
                "https://2ch.pm/mu/src/1476379/15188057063020.webm",
                //lil peep - save that shit
                "https://2ch.pm/mu/src/1476379/15188088045640.webm",
                // lil peep - drive by
                "https://2ch.pm/mu/src/1476379/15188119315120.webm",
                // MOVE - Nobody Reason
                "https://2ch.pm/mu/src/1476379/15190681725100.webm",
                // MOVE - Noizy Tribe
                "https://2ch.pm/mu/src/1476379/15190682426770.webm",
                // Xavier Wolf - 1st Summer Night
                "https://2ch.pm/mu/src/1476379/15190682915180.webm",
                // Xavier Wolf - Akina Speed Stars
                "https://2ch.pm/mu/src/1476379/15190683689820.webm",
                // Xavier Wolf - Date Night
                "https://2ch.pm/mu/src/1476379/15190684155060.webm",
                // Xavier Wolf - Pedals to the Metal
                "https://2ch.pm/mu/src/1476379/15190684621990.webm",
                // Xavier Wolf - The Cost 
                "https://2ch.pm/mu/src/1476379/15190685221460.webm",
                // Xavier Wolf - The Wulf of Akina
                "https://2ch.pm/mu/src/1476379/15190685802970.webm"
                };
            Random rnd = new Random();
            int index = rnd.Next(mus.Length);
            return mus[index];
        }

        private static Attachment GetAudioCard()
        {
            AudioCard audioCard = new AudioCard
            {
                Media = new List<MediaUrl>{
                  new MediaUrl(mus())

                }
            };
            return audioCard.ToAttachment();
        }
        
    }
    class Story
    {
        public string Header { get; set; }
        public string Text { get; set; }
    }


}