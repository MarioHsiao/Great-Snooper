﻿namespace GreatSnooper.Helpers
{
    using System.Collections.Generic;

    using GreatSnooper.Model;

    class Ranks
    {
        public static List<Rank> RankList
        {
            get;
            private set;
        }

        public static Rank Snooper
        {
            get;
            private set;
        }

        public static Rank Unknown
        {
            get;
            private set;
        }

        public static Rank GetRankByInt(int rank)
        {
            if (rank >= 0 && rank <= 13)
            {
                return RankList[rank];
            }
            return Unknown;
        }

        public static void Initialize()
        {
            RankList = new List<Rank>();
            RankList.Add(new Rank("Beginner"));
            RankList.Add(new Rank("Rookie"));
            RankList.Add(new Rank("Novice"));
            RankList.Add(new Rank("Average"));
            RankList.Add(new Rank("Above average"));
            RankList.Add(new Rank("Competent"));
            RankList.Add(new Rank("Veteran"));
            RankList.Add(new Rank("Highly distinguished"));
            RankList.Add(new Rank("Major"));
            RankList.Add(new Rank("Field Marshall"));
            RankList.Add(new Rank("Superstar"));
            RankList.Add(new Rank("Elite"));
            RankList.Add(new Rank("Unknown"));
            RankList.Add(new Rank("Snooper"));

            Unknown = RankList[12];
            Snooper = RankList[13];
        }
    }
}