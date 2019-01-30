﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Sparky.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sparky.Modules
{
    [RequireUserPermission(GuildPermission.ManageGuild)]
    [Summary("All moderation-related commands.")]
    public sealed class Moderation : SparkyModuleBase
    {
        [Command("addkarma")]
        [Summary("Manually add karma to a user (to remove, specify a negative amount).")]
        public async Task AddKarmaAsync([Summary("@user")] SocketGuildUser member, [Summary("1")] int toAdd)
        {
            var user = await Session.LoadAsync<SparkyUser>(member.Id.ToString());
            user.Karma += toAdd;

            await OkAsync();
        }

        [Command("addmsgcount")]
        [Summary("Manually add to a user's message count (to remove, specify a negative amount).")]
        public async Task AddMessageCountAsync([Summary("@user")] SocketGuildUser member, [Summary("1")] int toAdd)
        {
            var user = await Session.LoadAsync<SparkyUser>(member.Id.ToString());
            user.MessageCount += toAdd;

            await OkAsync();
        }

        [Command("prefix")]
        public async Task SetPrefixAsync([Remainder] string prefix)
        {
            Configuration.Write<string>("prefix", prefix);

            await OkAsync();
        }
    }
}