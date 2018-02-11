using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Scorables;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace ButtonBot.Dialogs
{
    [Serializable]
 
    public class RootDialog : IDialog<object>
    {
        private const string BredStories = "/b/Story";
        private const string HeroCard = "Hero card";
        private const string SigninCard = "Sign-in card";
        private const string AnimationCard = "Animation card";
        private const string VideoCard = "Video card";
        private const string AudioCard = "Audio card";
        private const string PicrandomCard = "Pic random";
        
        private IEnumerable<string> options = new List<string> {BredStories, HeroCard, PicrandomCard, SigninCard, AnimationCard, VideoCard, AudioCard };
        public async Task StartAsync(IDialogContext context)
        {
            
            context.Wait(MessageReceivedAsync);
        }


        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IActivity> result)
        {
            Attachment create = new HeroCard
            {
                Buttons = new List<CardAction>
                {
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
        private static Attachment GetStory()
        {
            HeroCard heroCard = new HeroCard
            {
                Title = "Amazing stories",
                Subtitle = "",
                Text = Pasts()
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
                    "https://pp.userapi.com/c834201/v834201258/b0ace/Dhuw6DOmFgc.jpg"
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

        private static Attachment GetVideoCard()
        {
            VideoCard videoCard = new VideoCard
            {
                Media = new List<MediaUrl>{
                    new MediaUrl()
                    {
                        Url = "https://2ch.pm/b/src/169827728/15174870919881.mp4"
                    }
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

        private static Attachment GetAudioCard()
        {
            AudioCard audioCard = new AudioCard
            {
                Media = new List<MediaUrl>{
                    new MediaUrl
                    {
                        Url = "https://cs9-2v4.userapi.com/p22/2aed7071c17333.mp3?extra=p9q0h0Ay4Xs-6mBts2yW2hgWtKnQGRdt-6tP2BWuyY8SHlCryo36NK94ViA26uReimjLFtXVQo8rJ1QWdFhXlNL3qDo6zGUqXYkhAoLRuJYTZAHL1PdwGcdyymndTauZ_Fn-Lx8zIg#FILENAME/Good Times - %D0%96%D0%B8%D0%B7%D0%BD%D1%8C %D1%85%D0%BE%D1%80%D0%BE%D1%88%D0%B0.mp3"
                    }
                }
            };
            return audioCard.ToAttachment();
        }
        public static string Pasts()
        {
            string[] stories =
            {
                "text1",
                "text2",
                "text3",
                "text4",
                "text5"
            };
            Random rnd = new Random();
            int index = rnd.Next(stories.Length);
            return stories[index];
        }
    }



}