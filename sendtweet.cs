﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net;
using TweetSharp;
using Newtonsoft.Json;

namespace Twitterbot
{
    public class SendTweet
    {
        private static TwitterService service = new TwitterService(Apikeys.api_key, Apikeys.api_key_secret, Apikeys.access_token, Apikeys.access_token_secret);

        public void TweetSend(string _status)
        {
            service.SendTweet(new SendTweetOptions { Status = _status }, (tweet, response) =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"<{DateTime.Now}> - Tweet Sent!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"<{DateTime.Now}> - Encountered an Error.");
                    Console.ResetColor();
                }
            });
        }
    }
}
