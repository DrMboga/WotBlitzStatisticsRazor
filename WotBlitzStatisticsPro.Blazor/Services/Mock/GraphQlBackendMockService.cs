﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Model;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using WotBlitzStatisticsPro.Blazor.Helpers;

namespace WotBlitzStatisticsPro.Blazor.Services.Mock
{
    public class GraphQlBackendMockService: IGraphQlBackendService
    {
        private readonly bool _needToWait;

        public GraphQlBackendMockService()
        {
            _needToWait = true;
        }

        public GraphQlBackendMockService(bool needToWait)
        {
            _needToWait = needToWait;
        }

        public async Task<IReadOnlyList<IPlayerShortInfo>?> FindPlayers(string accountNick, RealmType realmType)
        {
            var result = new List<IFindPlayers_Players>();

            var faker = new Faker(FakerLanguage(GetLanguage()));
            var random = faker.Random.Number(10, 80);

            for (int i = 0; i < random; i++)
            {
                result.Add(new FindPlayers_Players_AccountsSearchResponseItem(
                    faker.Random.Long(100000, 999999),
                    faker.Internet.UserName(),
                    faker.Hacker.Abbreviation().OrNull(faker, 0.6f),
                    faker.Date.Past(),
                    faker.Random.Number(10, 20000),
                    faker.Random.Number(30, 90)));
            }

            if (_needToWait)
            {
                await Task.Delay(1000);
            }

            return result;
        }

        public async Task<IReadOnlyList<IClanShortInfo>?> FindClans(string clanNameOrTag, RealmType realmType)
        {
            var result = new List<IFindClans_Clans>();

            var faker = new Faker(FakerLanguage(GetLanguage()));
            var random = faker.Random.Number(10, 80);

            for (int i = 0; i < random; i++)
            {
                result.Add(new FindClans_Clans_ClanSearchResponseItem(
                    faker.Random.Long(100000, 999999),
                    Convert.ToInt32((faker.Date.Past() - new DateTime(1970, 1, 1)).TotalSeconds),
                    faker.Random.Number(1, 50),
                    faker.Lorem.Word(),
                    faker.Hacker.Abbreviation()));
            }


            if (_needToWait)
            {
                await Task.Delay(1000);
            }

            return result;
        }

        public async Task<(IAccount accountInfo, IReadOnlyList<ISection> achievementsBySection)> GetPlayerInfo(long accountId, RealmType realmType)
        {
            var faker = new Faker(FakerLanguage(GetLanguage()));
            var isClanInfo = faker.Random.Bool();

            IPlayer_AccountInfo_ClanInfo clanInfo = null;

            if (isClanInfo)
            {
                var role = GetRandomClanRole(faker, GetLanguage());
                clanInfo = new Player_AccountInfo_ClanInfo_ClanInfoResponse(
                    faker.Random.Long(100000, 999999),
                    faker.Date.Past(),
                    role.role,
                    role.roleName,
                    faker.Lorem.Word(),
                    faker.Date.Past(),
                    faker.Random.Long(100000, 999999),
                    faker.Internet.UserName(),
                    faker.Lorem.Sentence(),
                    faker.Lorem.Sentence(),
                    faker.Random.Long(100000, 999999),
                    faker.Internet.UserName(),
                    faker.Random.Number(1, 50),
                    faker.Lorem.Sentence(),
                    faker.Hacker.Abbreviation(),
                    faker.Date.Past()
                );
            }

            var jObject = JObject.Parse(VehiclesMockData.TanksList);
            var tankTokens = jObject["tanks"];
            var tanks = new List<IPlayer_AccountInfo_Tanks>();
            foreach (var tankToken in tankTokens)
            {
                tanks.Add(new Player_AccountInfo_Tanks_TankInfoResponse(
                    tankToken["TankId"].Value<long>(),
                    tankToken["BattleLifeTimeInSeconds"].IsNullOrEmpty() ? 0 : tankToken["BattleLifeTimeInSeconds"].Value<int>(),
                    tankToken["MarkOfMastery"].IsNullOrEmpty() ? MarkOfMastery.None : (MarkOfMastery)tankToken["MarkOfMastery"].Value<int>(),
                    tankToken["AvgBattleLifeTimeInMinutes"].IsNullOrEmpty() ? 0M : tankToken["AvgBattleLifeTimeInMinutes"].Value<decimal>(),
                    tankToken["Name"].IsNullOrEmpty() ? string.Empty : tankToken["Name"].Value<string>(),
                    tankToken["TankNationId"].IsNullOrEmpty() ? string.Empty : tankToken["TankNationId"].Value<string>(),
                    tankToken["TankNation"].IsNullOrEmpty() ? string.Empty : tankToken["TankNation"].Value<string>(),
                    tankToken["Tier"].IsNullOrEmpty() ? 0 : tankToken["Tier"].Value<int>(),
                    tankToken["TankTypeId"].IsNullOrEmpty() ? string.Empty : tankToken["TankTypeId"].Value<string>(),
                    tankToken["TankType"].IsNullOrEmpty() ? string.Empty : tankToken["TankType"].Value<string>(),
                    tankToken["IsPremium"].IsNullOrEmpty() ? false : tankToken["IsPremium"].Value<bool>(),
                    tankToken["PreviewImage"].IsNullOrEmpty() ? string.Empty : tankToken["PreviewImage"].Value<string>(),
                    tankToken["NormalImage"].IsNullOrEmpty() ? string.Empty : tankToken["NormalImage"].Value<string>(),
                    tankToken["LastBattleTime"].IsNullOrEmpty() ? DateTime.MinValue : tankToken["LastBattleTime"].Value<DateTime>(),
                    tankToken["Battles"].IsNullOrEmpty() ? 0 : tankToken["Battles"].Value<long>(),
                    tankToken["CapturePoints"].IsNullOrEmpty() ? 0 : tankToken["CapturePoints"].Value<long>(),
                    tankToken["DamageDealt"].IsNullOrEmpty() ? 0 : tankToken["DamageDealt"].Value<long>(),
                    tankToken["DamageReceived"].IsNullOrEmpty() ? 0 : tankToken["DamageReceived"].Value<long>(),
                    tankToken["DroppedCapturePoints"].IsNullOrEmpty() ? 0 : tankToken["DroppedCapturePoints"].Value<long>(),
                    tankToken["Frags"].IsNullOrEmpty() ? 0 : tankToken["Frags"].Value<long>(),
                    tankToken["Frags8P"].IsNullOrEmpty() ? 0 : tankToken["Frags8P"].Value<long>(),
                    tankToken["Hits"].IsNullOrEmpty() ? 0 : tankToken["Hits"].Value<long>(),
                    tankToken["Losses"].IsNullOrEmpty() ? 0 : tankToken["Losses"].Value<long>(),
                    tankToken["MaxFrags"].IsNullOrEmpty() ? 0 : tankToken["MaxFrags"].Value<long>(),
                    tankToken["MaxXp"].IsNullOrEmpty() ? 0 : tankToken["MaxXp"].Value<long>(),
                    tankToken["Shots"].IsNullOrEmpty() ? 0 : tankToken["Shots"].Value<long>(),
                    tankToken["Spotted"].IsNullOrEmpty() ? 0 : tankToken["Spotted"].Value<long>(),
                    tankToken["SurvivedBattles"].IsNullOrEmpty() ? 0 : tankToken["SurvivedBattles"].Value<long>(),
                    tankToken["WinAndSurvived"].IsNullOrEmpty() ? 0 : tankToken["WinAndSurvived"].Value<long>(),
                    tankToken["Wins"].IsNullOrEmpty() ? 0 : tankToken["Wins"].Value<long>(),
                    tankToken["Xp"].IsNullOrEmpty() ? 0 : tankToken["Xp"].Value<long>(),
                    tankToken["Wn7"].IsNullOrEmpty() ? 0 : tankToken["Wn7"].Value<double>(),
                    tankToken["WinRate"].IsNullOrEmpty() ? 0M : tankToken["WinRate"].Value<decimal>(),
                    tankToken["AvgDamage"].IsNullOrEmpty() ? 0M : tankToken["AvgDamage"].Value<decimal>(),
                    tankToken["AvgXp"].IsNullOrEmpty() ? 0M : tankToken["AvgXp"].Value<decimal>(),
                    tankToken["DamageCoefficient"].IsNullOrEmpty() ? 0M : tankToken["DamageCoefficient"].Value<decimal>(),
                    tankToken["SurvivalRate"].IsNullOrEmpty() ? 0M : tankToken["SurvivalRate"].Value<decimal>()
                ));
            }
            // for (int i = 0; i < tanksCount; i++)
            // {
            //     var nation = GetRandomNation(faker, GetLanguage());
            //     var vehicleType = GetRandomVehicleType(faker, GetLanguage());
            //     tanks.Add(new Player_AccountInfo_Tanks_TankInfoResponse(
            //         faker.Random.Long(100000, 999999),
            //         faker.Random.Number(500),
            //         faker.PickRandom<MarkOfMastery>(),
            //         faker.Random.Decimal(0M, 7M),
            //         faker.Name.LastName(),
            //         nation.nation,
            //         nation.nationName,
            //         faker.Random.Number(1, 10),
            //         vehicleType.vehicleType,
            //         vehicleType.vehicleTypeName,
            //         faker.Random.Bool(),
            //         GetRandomPreviewImage(faker),
            //         GetRandomLargeImage(faker),
            //         faker.Date.Past(),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Long(1, 9999),
            //         faker.Random.Double(500D, 2000D),
            //         faker.Random.Decimal(20M, 95M),
            //         faker.Random.Decimal(300M, 4000M),
            //         faker.Random.Decimal(100M, 2000M),
            //         faker.Random.Decimal(0M, 3M),
            //         faker.Random.Decimal(5M, 95M)
            //     ));
            // }

            if (_needToWait)
            {
                await Task.Delay(1000);
            }

            var player = new Player_AccountInfo_AccountInfoResponse(
                accountId,
                faker.Date.Past(),
                faker.Internet.UserName(),
                tanks[faker.Random.Number(1, tanks.Count - 1)].TankId,
                tanks[faker.Random.Number(1, tanks.Count - 1)].TankId,
                faker.Random.Double(2D, 9D),
                faker.Date.Past(),
                faker.Random.Long(1, 100000),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Long(1, 9999),
                faker.Random.Double(500D, 2000D),
                faker.Random.Decimal(20M, 95M),
                faker.Random.Decimal(300M, 4000M),
                faker.Random.Decimal(100M, 2000M),
                faker.Random.Decimal(0M, 3M),
                faker.Random.Decimal(5M, 95M),
                clanInfo,
                tanks
            );

            var achievements = AchievementsMockData.GetStaticAchievements();

            return (player, achievements?.Sections);
        }

        public Task<string> GetWgLoginUrl(RealmType realmType)
        {
            return Task.FromResult(
                "https://api.worldoftanks.eu/wot/auth/login/?application_id=adc1387489cf9fc8d9a1d85dbd27763d");
        }

        private string FakerLanguage(RequestLanguage language)
        {
            switch (language)
            {
                case RequestLanguage.Ru:
                    return "ru";
                case RequestLanguage.De:
                    return "de";
                default:
                    return "en";
            }
        }

        private RequestLanguage GetLanguage()
        {
            var culture = CultureInfo.CurrentCulture;

            switch (culture.Name)
            {
                case "ru-RU":
                    return RequestLanguage.Ru;
                case "de-DE":
                    return RequestLanguage.De;
                default:
                    return RequestLanguage.En;
            }
        }

        private (string role, string roleName) GetRandomClanRole(Faker faker, RequestLanguage language)
        {
            var roles = new string[] {"executive_officer", "private", "commander"};
            var roleIndex = faker.Random.Number(0, 2);
            var result = (roleIndex, language) switch
            {
                (0, RequestLanguage.Ru) => "Заместитель командующего",
                (0, RequestLanguage.En) => "Executive Officer",
                (0, RequestLanguage.De) => "Ausführender Offizier",
                (1, RequestLanguage.Ru) => "Боец",
                (1, RequestLanguage.En) => "Private",
                (1, RequestLanguage.De) => "Gefreiter",
                (2, RequestLanguage.Ru) => "Командующий",
                (2, RequestLanguage.En) => "Commander",
                (2, RequestLanguage.De) => "Kommandant",
                _ => "Unknown"
            };

            return (roles[roleIndex], result);
        }

        private (string vehicleType, string vehicleTypeName) GetRandomVehicleType(Faker faker, RequestLanguage language)
        {
            var types = new string[] { "heavyTank", "AT-SPG", "mediumTank", "lightTank" };
            var typeIndex = faker.Random.Number(0, 3);
            var result = (roleIndex: typeIndex, language) switch
            {
                (0, RequestLanguage.Ru) => "Тяжёлый танк",
                (0, RequestLanguage.En) => "Heavy Tank",
                (0, RequestLanguage.De) => "Schwere Panzer",
                (1, RequestLanguage.Ru) => "ПТ-САУ",
                (1, RequestLanguage.En) => "Tank Destroyer",
                (1, RequestLanguage.De) => "Jagdpanzer",
                (2, RequestLanguage.Ru) => "Средний танк",
                (2, RequestLanguage.En) => "Medium Tank",
                (2, RequestLanguage.De) => "Mittlerer Panzer",
                (3, RequestLanguage.Ru) => "Легкий танк",
                (3, RequestLanguage.En) => "Light Tank",
                (3, RequestLanguage.De) => "Leichter Panzer",
                _ => "Unknown"
            };

            return (types[typeIndex], result);
        }

        private (string nation, string nationName) GetRandomNation(Faker faker, RequestLanguage language)
        {
            var nations = new string[] { "usa", "france", "ussr", "china", "uk", "japan", "germany", "other", "european" };
            var nationIndex = faker.Random.Number(0, 8);
            var result = (roleIndex: nationIndex, language) switch
            {
                (0, RequestLanguage.Ru) => "США",
                (0, RequestLanguage.En) => "U.S.A.",
                (0, RequestLanguage.De) => "USA",
                (1, RequestLanguage.Ru) => "Франция",
                (1, RequestLanguage.En) => "France",
                (1, RequestLanguage.De) => "Frankreich",
                (2, RequestLanguage.Ru) => "СССР",
                (2, RequestLanguage.En) => "U.S.S.R.",
                (2, RequestLanguage.De) => "UdSSR",
                (3, RequestLanguage.Ru) => "Китай",
                (3, RequestLanguage.En) => "China",
                (3, RequestLanguage.De) => "China",
                (4, RequestLanguage.Ru) => "Великобритания",
                (4, RequestLanguage.En) => "U.K.",
                (4, RequestLanguage.De) => "Großbritannien",
                (5, RequestLanguage.Ru) => "Япония",
                (5, RequestLanguage.En) => "Japan",
                (5, RequestLanguage.De) => "Japan",
                (6, RequestLanguage.Ru) => "Германия",
                (6, RequestLanguage.En) => "Germany",
                (6, RequestLanguage.De) => "Deutschland",
                (7, RequestLanguage.Ru) => "Сборная нация",
                (7, RequestLanguage.En) => "Hybrid nation",
                (7, RequestLanguage.De) => "Hybridnation",
                (8, RequestLanguage.Ru) => "Сборная Европы",
                (8, RequestLanguage.En) => "European Nation",
                (8, RequestLanguage.De) => "Europäische Nation",
                _ => "Unknown"
            };

            return (nations[nationIndex], result);
        }

        private string GetRandomPreviewImage(Faker faker)
        {
            var images = new string[]
            {
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/T-34.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/Ch12_111_1_2_3.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/VK3601H.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/AMX_50B.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/GB72_AT15.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/IS-4.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/T2_lt.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/D2.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/AMX40.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/T-34-85_Victory.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/IS.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/T32.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/F19_Lorraine40t.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/PzVIB_Tiger_II.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/AMX50_Foch.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/GAZ-74b.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/S17_EMIL_1952E2.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/Pz38_NA.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/M103.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/E50_Ausf_M.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/Oth17_BDT-5A.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/GB_Vickers_Light_105.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/GB23_Centurion.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/Bat_Chatillon25t.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/M4_Sherman.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/Ch23_112.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/JagdPz_E100.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/T62A.png",
            };

            return images[faker.Random.Number(images.Length - 1)];
        }

        private string GetRandomLargeImage(Faker faker)
        {
            var images = new string[]
            {
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/T-34.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/Ch12_111_1_2_3.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/VK3601H.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/AMX_50B.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/GB72_AT15.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/IS-4.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/T2_lt.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/D2.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/AMX40.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/T-34-85_Victory.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/IS.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/T32.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/F19_Lorraine40t.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/PzVIB_Tiger_II.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/AMX50_Foch.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/GAZ-74b.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/S17_EMIL_1952E2.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/Pz38_NA.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/M103.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/E50_Ausf_M.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/Oth17_BDT-5A.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/GB_Vickers_Light_105.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/GB23_Centurion.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/Bat_Chatillon25t.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/M4_Sherman.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/Ch23_112.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/JagdPz_E100.png",
                "http://glossary-eu-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd/T62A.png",
            };

            return images[faker.Random.Number(images.Length - 1)];
        }

        public Task<LoginInfo> ProlongToken(long accountId, string oldToken, RealmType realmType)
        {
            return Task.FromResult(new LoginInfo { AccountId = accountId, AccessToken = oldToken, Realm = realmType, ExpiresAt = 1631182800, NickName = "Fake nick"});
        }

        public Task CollectPlayerInfo(long accountId, RealmType realmType, string accessToken)
        {
            return Task.CompletedTask;
        }

        public Task<LoginInfo> ProlongToken(string oldToken, RealmType realmType)
        {
            return Task.FromResult(new LoginInfo { AccessToken = oldToken, Realm = realmType, ExpiresAt = 1631182800, NickName = "Fake nick" });
        }

        public Task<string> Logout(string token, RealmType realmType)
        {
            return Task.FromResult("Fake logout");
        }
        public Task<IReadOnlyList<IDictionary_Vehicles>> GetVehiclesByNation(string nationId) 
        {
            var jObject = JObject.Parse(VehiclesMockData.VehiclesDictionary);
            var vehicleTokens = jObject["vehicles"];
            var result = new List<IDictionary_Vehicles>();
            foreach (var vehicleObject in vehicleTokens)
            {
                var nextTanks = new List<long>();
                foreach (var next in vehicleObject["NexTanksInTree"])
                {
                    nextTanks.Add(next.Value<long>());
                }
                result.Add(new Dictionary_Vehicles_VehicleResponse(
                    vehicleObject["TankId"].Value<long>(),
                    vehicleObject["Name"].Value<string>(),
                    vehicleObject["Description"].Value<string>(),
                    vehicleObject["IsPremium"].Value<bool>(),
                    vehicleObject["TypeId"].Value<string>(),
                    vehicleObject["NationId"].Value<string>(),
                    vehicleObject["Tier"].Value<int>(),
                    vehicleObject["PreviewImage"].Value<string>(),
                    vehicleObject["NormalImage"].Value<string>(),
                    vehicleObject["PriceCredit"].Value<decimal>(),
                    vehicleObject["PriceGold"].Value<decimal>(),
                    nextTanks.AsReadOnly()
                ));
            }
            return Task.FromResult((IReadOnlyList<IDictionary_Vehicles>)result.AsReadOnly());
        }
    }
}